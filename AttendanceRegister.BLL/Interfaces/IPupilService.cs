using AttendanceRegister.BLL.Models;

namespace AttendanceRegister.BLL.Interfaces
{
    public interface IPupilService
    {
        Task<OperationResult<PupilModel>> GetPupilAsync(string username, string password);

        Task<OperationResult<List<PupilModel>>> GetAllPupilsAsync();
    }
}
