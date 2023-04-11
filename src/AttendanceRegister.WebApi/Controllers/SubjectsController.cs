using AttendanceRegister.BLL.Interfaces;
using AttendanceRegister.BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceRegister.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectModel>>> GetAll()
        {
            var subjectsOr = await _subjectService.GetAllSubjectsAsync();
            return Ok(subjectsOr.Entity);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectModel>> GetById(int id)
        {
            var subjectOr = await _subjectService.GetSubjectByIdAsync(id);
            return subjectOr.IsSuccess ? Ok(subjectOr.Entity) : BadRequest(subjectOr.Errors);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("teachers")]
        public async Task<ActionResult<SubjectModel>> UpdateSubjectTeachersClasses(SubjectModel newModel)
        {
            var resp = await _subjectService.UpdateSubjectTeachersClassesAsync(newModel);
            return resp.IsSuccess ? Ok(resp.Entity) : BadRequest(resp.Errors);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<SubjectModel>> AddSubject(SubjectModel newSubject)
        {
            var resp = await _subjectService.AddSubjectAsync(newSubject);
            return resp.IsSuccess ? Ok(resp.Entity) : BadRequest(resp.Errors);
        }

        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<ActionResult<SubjectModel>> UpdateSubject(SubjectModel subjectModel)
        {
            var resp = await _subjectService.UpdateSubjectAsync(subjectModel);
            return resp.IsSuccess ? Ok(resp.Entity) : BadRequest(resp.Errors);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var resp = await _subjectService.DeleteSubjectAsync(id);
            return resp.IsSuccess ? Ok() : BadRequest(resp.Errors);
        }
    }
}
