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
    }
}
