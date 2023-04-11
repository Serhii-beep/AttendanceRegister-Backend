using AttendanceRegister.BLL.Models;

namespace AttendanceRegister.BLL.Interfaces
{
    public interface IClassProfileService
    {
        Task<OperationResult<IEnumerable<ClassProfileModel>>> GetAllClassesByProfilesAsync();

        Task<OperationResult<IEnumerable<ClassProfileModel>>> GetAllProfilesAsync();
    }
}
