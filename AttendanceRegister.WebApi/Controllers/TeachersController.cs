using AttendanceRegister.BLL.Interfaces;
using AttendanceRegister.BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AttendanceRegister.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly ITeacherService _teacherService;

        public TeachersController(IConfiguration configuration, ITeacherService teacherService)
        {
            _configuration = configuration;
            _teacherService = teacherService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate(TeacherModel teacher)
        {
            var teacherOr = await _teacherService.GetTeacherAsync(teacher.Login, teacher.Password);
            if(!teacherOr.IsSuccess)
            {
                return Unauthorized(teacherOr.Errors);
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, teacher.Login)
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(tokenHandler.WriteToken(token));
        }
    }
}
