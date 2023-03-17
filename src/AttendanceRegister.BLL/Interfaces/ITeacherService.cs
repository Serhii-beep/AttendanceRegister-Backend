using AttendanceRegister.BLL.Models;

namespace AttendanceRegister.BLL.Interfaces
{
    public interface ITeacherService
    {
        Task<OperationResult<TeacherModel>> GetTeacherAsync(string username, string password);

        Task<OperationResult<IEnumerable<TeacherModel>>> GetAllTeachersAsync(string order, int page, int itemsPerPage);

        Task<OperationResult<TeacherModel>> AddTeacherAsync(TeacherModel teacher);

        Task<OperationResult<TeacherModel>> UpdateTeacherAsync(TeacherModel teacher);

        Task<OperationResult<TeacherModel>> DeleteTeacherByIdAsync(int id);
    }
}
