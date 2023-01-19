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
    public class PupilsController : ControllerBase
    {
        private readonly IPupilService _pupilService;

        public PupilsController(IPupilService pupilService)
        {
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
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, pupil.Username),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, pupil.Role)
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            var jwt = new JwtSecurityToken(
                claims: claimsIdentity.Claims,
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(jwt), user = pupilOr.Entity });
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<PupilModel>>> GetAllPupils()
        {
            var pupilsOr = await _pupilService.GetAllPupilsAsync();
            if(!pupilsOr.IsSuccess)
            {
                return BadRequest(pupilsOr.Errors);
            }
            return Ok(pupilsOr.Entity);
        }

    }
}
