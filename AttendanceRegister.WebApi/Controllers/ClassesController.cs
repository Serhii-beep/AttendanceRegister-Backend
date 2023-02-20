using AttendanceRegister.BLL.Interfaces;
using AttendanceRegister.BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceRegister.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassesController(IClassService classService)
        {
            _classService = classService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassModel>>> GetAll()
        {
            var classesOr = await _classService.GetAllClassesAsync();
            return classesOr.IsSuccess ? Ok(classesOr.Entity) : BadRequest(classesOr.Errors);
        }

        [Authorize]
        [HttpGet("included")]
        public async Task<ActionResult<IEnumerable<ClassInfoModel>>> GetAllIncluded()
        {
            var classesOr = await _classService.GetClassesIncludedAsync();
            return classesOr.IsSuccess ? Ok(classesOr.Entity) : BadRequest(classesOr.Errors);
        }

    }
}
