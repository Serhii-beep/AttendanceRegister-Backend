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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassProfileModel>>> GetAll()
        {
            var classProfilesOr = await _classProfileService.GetAllClassesByProfiles();
            return classProfilesOr.IsSuccess ? Ok(classProfilesOr.Entity) : BadRequest(classProfilesOr.Errors);
        }
    }
}
