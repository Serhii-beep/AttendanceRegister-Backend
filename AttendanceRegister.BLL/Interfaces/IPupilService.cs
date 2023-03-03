using AttendanceRegister.BLL.Models;

namespace AttendanceRegister.BLL.Interfaces
{
    public interface IPupilService
    {
        Task<OperationResult<PupilModel>> GetPupilAsync(string username, string password);

        Task<OperationResult<List<PupilModel>>> GetAllPupilsAsync();

        Task<OperationResult<List<PupilModel>>> GetPupilsAsync(string order, int page, int itemsPerPage);

        Task<OperationResult<PupilModel>> AddPupilAsync(PupilModel pupil);

        Task<OperationResult<PupilModel>> UpdatePupilAsync(PupilModel pupil);

        Task<OperationResult<PupilModel>> DeletePupilByIdAsync(int id);
    }
}
