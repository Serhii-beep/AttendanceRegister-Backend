using AttendanceRegister.BLL.Models;

namespace AttendanceRegister.BLL.Interfaces
{
    public interface ITeacherService
    {
        Task<OperationResult<TeacherModel>> GetTeacherAsync(string username, string password);
    }
}
