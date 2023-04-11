using AttendanceRegister.BLL.Interfaces;
using AttendanceRegister.BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Attendanceregister.DAL.Entities;
using AttendanceRegister.BLL.JWTAuth;

namespace AttendanceRegister.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminsController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate(UserAuthorizationModel user)
        {
            var us = await _adminService.GetUserAsync(user.Username, user.Password);
            AdminModel admin;
            TeacherModel teacher;
            PupilModel pupil;
            if(!us.IsSuccess)
            {
                return Unauthorized(us.Errors);
            }
            if(us.Entity is AdminModel modeladmin)
            {
                admin = modeladmin;
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, admin.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, admin.Role)
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                var jwt = new JwtSecurityToken(
                    claims: claimsIdentity.Claims,
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(jwt), user = admin });
            }
            else if(us.Entity is TeacherModel modelteacher)
            {
                teacher = modelteacher;
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, teacher.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, teacher.Role)
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                var jwt = new JwtSecurityToken(
                    claims: claimsIdentity.Claims,
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(jwt), user = teacher });
            }
            else
            {
                pupil = us.Entity as PupilModel;
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, pupil.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, pupil.Role)
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                var jwt = new JwtSecurityToken(
                    claims: claimsIdentity.Claims,
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(jwt), user = pupil });
            }
        }
    }
}
