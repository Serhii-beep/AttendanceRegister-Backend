using AttendanceRegister.BLL.Models;

namespace AttendanceRegister.BLL.Interfaces
{
    public interface ISubjectService
    {
        Task<OperationResult<IEnumerable<SubjectModel>>> GetAllSubjectsAsync();
    }
}
