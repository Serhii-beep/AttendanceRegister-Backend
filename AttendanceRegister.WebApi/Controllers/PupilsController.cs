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

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<PupilModel>>> GetAllPupils()
        {
            var pupilsOr = await _pupilService.GetAllPupilsAsync();
            return pupilsOr.IsSuccess ? Ok(pupilsOr.Entity) : BadRequest(pupilsOr.Errors);
        }

        [Authorize]
        [HttpGet("order={order}&page={page:int}&itemsPerPage={itemsPerPage:int}")]
        public async Task<ActionResult<List<PupilModel>>> GetSortedAndPaginated(string order, int page, int itemsPerPage)
        {
            var pupilsOr = await _pupilService.GetPupilsAsync(order, page, itemsPerPage);
            return pupilsOr.IsSuccess ? Ok(pupilsOr.Entity) : BadRequest(pupilsOr.Errors);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<PupilModel>> AddPupil(PupilModel pupil)
        {
            var pupilOr = await _pupilService.AddPupilAsync(pupil);
            return pupilOr.IsSuccess ? Ok(pupilOr.Entity) : BadRequest(pupilOr.Errors);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var pupilOr = await _pupilService.DeletePupilByIdAsync(id);
            return pupilOr.IsSuccess ? Ok() : BadRequest(pupilOr.Errors);
        }

        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<ActionResult<PupilModel>> UpdatePupil(PupilModel pupil)
        {
            var pupilOr = await _pupilService.UpdatePupilAsync(pupil);
            return pupilOr.IsSuccess ? Ok(pupilOr.Entity) : BadRequest(pupilOr.Errors);
        }
    }
}
