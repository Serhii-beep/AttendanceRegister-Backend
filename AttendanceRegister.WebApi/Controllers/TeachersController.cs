using Attendanceregister.DAL.Entities;
using AttendanceRegister.BLL.Interfaces;
using AttendanceRegister.BLL.JWTAuth;
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
        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate(UserAuthorizationModel teacher)
        {
            var teacherOr = await _teacherService.GetTeacherAsync(teacher.Username, teacher.Password);
            if(!teacherOr.IsSuccess)
            {
                return Unauthorized(teacherOr.Errors);
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, teacher.Username),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, teacher.Role)
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            var jwt = new JwtSecurityToken(
                claims: claimsIdentity.Claims,
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(jwt), user = teacherOr.Entity });
        }
    }
}
