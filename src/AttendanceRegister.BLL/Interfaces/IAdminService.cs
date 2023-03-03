using AttendanceRegister.BLL.Models;

namespace AttendanceRegister.BLL.Interfaces
{
    public interface IAdminService
    {
        Task<OperationResult<AdminModel>> GetAdminAsync(string username, string password);
    }
}
