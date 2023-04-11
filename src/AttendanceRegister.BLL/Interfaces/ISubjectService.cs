using AttendanceRegister.BLL.Models;

namespace AttendanceRegister.BLL.Interfaces
{
    public interface ISubjectService
    {
        Task<OperationResult<IEnumerable<SubjectModel>>> GetAllSubjectsAsync();

        Task<OperationResult<SubjectModel>> GetSubjectByIdAsync(int id);

        Task<OperationResult<SubjectModel>> UpdateSubjectTeachersClassesAsync(SubjectModel subjectModel);

        Task<OperationResult<SubjectModel>> AddSubjectAsync(SubjectModel newSubject);

        Task<OperationResult<SubjectModel>> UpdateSubjectAsync(SubjectModel subjectModel);

        Task<OperationResult<bool>> DeleteSubjectAsync(int id);
    }
}
