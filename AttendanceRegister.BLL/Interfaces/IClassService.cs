using AttendanceRegister.BLL.Models;

namespace AttendanceRegister.BLL.Interfaces
{
    public interface IClassService
    {
        Task<OperationResult<IEnumerable<ClassModel>>> GetAllClassesAsync();

        Task<OperationResult<IEnumerable<ClassInfoModel>>> GetClassesIncludedAsync();

        Task<OperationResult<ClassModel>> DeleteClassByIdAsync(int id);

        Task<OperationResult<ClassModel>> UpdateClassAsync(ClassModel classModel);
    }
}
