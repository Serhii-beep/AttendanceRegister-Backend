using Attendanceregister.DAL.Entities;
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
    public class PupilsController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly IPupilService _pupilService;

        public PupilsController(IConfiguration configuration, IPupilService pupilService)
        {
            _configuration = configuration;
            _pupilService = pupilService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate(UserAuthorizationModel pupil)
        {
            var pupilOr = await _pupilService.GetPupilAsync(pupil.Username, pupil.Password);
            if(!pupilOr.IsSuccess)
            {
                return Unauthorized(pupilOr.Errors);
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, pupil.Username)
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new { token = tokenHandler.WriteToken(token), user = pupilOr.Entity });
        }
    }
}
