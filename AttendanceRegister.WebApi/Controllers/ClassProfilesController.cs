using AttendanceRegister.BLL.Interfaces;
using AttendanceRegister.BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceRegister.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassProfilesController : ControllerBase
    {
        private readonly IClassProfileService _classProfileService;

        public ClassProfilesController(IClassProfileService classProfileService)
        {
            _classProfileService = classProfileService;
        }

        [Authorize]
        [HttpGet("included")]
        public async Task<ActionResult<IEnumerable<ClassProfileModel>>> GetAllIncluded()
        {
            var classProfilesOr = await _classProfileService.GetAllClassesByProfilesAsync();
            return classProfilesOr.IsSuccess ? Ok(classProfilesOr.Entity) : BadRequest(classProfilesOr.Errors);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassProfileModel>>> GetAll()
        {
            var profilesOr = await _classProfileService.GetAllProfilesAsync();
            return profilesOr.IsSuccess ? Ok(profilesOr.Entity) : BadRequest(profilesOr.Errors);
        }
    }
}
