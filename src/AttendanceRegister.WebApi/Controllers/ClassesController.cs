using AttendanceRegister.BLL.Interfaces;
using AttendanceRegister.BLL.Models;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassModel>> GetById(int id)
        {
            var classOr = await _classService.GetClassByIdAsync(id);
            return classOr.IsSuccess ? Ok(classOr.Entity) : BadRequest(classOr.Errors);
        }

        [Authorize]
        [HttpGet("included")]
        public async Task<ActionResult<IEnumerable<ClassInfoModel>>> GetAllIncluded()
        {
            var classesOr = await _classService.GetClassesIncludedAsync();
            return classesOr.IsSuccess ? Ok(classesOr.Entity) : BadRequest(classesOr.Errors);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<ClassModel>> AddClass(ClassModel model)
        {
            var classOr = await _classService.AddClassAsync(model);
            return classOr.IsSuccess ? Ok(classOr.Entity) : BadRequest(classOr.Errors); 
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClassModel>> DeleteById(int id)
        {
            var classOr = await _classService.DeleteClassByIdAsync(id);
            return classOr.IsSuccess ? Ok(classOr.Entity) : BadRequest(classOr.Errors);
        }

        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<ActionResult<ClassModel>> UpdateAsync(ClassModel classModel)
        {
            var classOr = await _classService.UpdateClassAsync(classModel);
            return classOr.IsSuccess ? Ok(classOr.Entity) : BadRequest(classOr.Errors);
        }
    }
}
