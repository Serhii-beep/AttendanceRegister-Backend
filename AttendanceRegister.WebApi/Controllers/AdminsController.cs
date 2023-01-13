using AttendanceRegister.BLL.Interfaces;
using AttendanceRegister.BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace AttendanceRegister.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly IAdminService _adminService;

        public AdminsController(IConfiguration configuration, IAdminService adminService)
        {
            _configuration = configuration;
            _adminService = adminService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate(AdminModel admin)
        {
            var adminOr = await _adminService.GetAdminAsync(admin.Login, admin.Password);
            if(!adminOr.IsSuccess)
            {
                return Unauthorized(adminOr.Errors);
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, admin.Login)
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(tokenHandler.WriteToken(token));
        }
    }
}
