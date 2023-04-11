using AttendanceRegister.BLL.Models;

namespace AttendanceRegister.BLL.Interfaces
{
    public interface IAdminService
    {
        Task<OperationResult<object>> GetUserAsync(string username, string password);
    }
}
