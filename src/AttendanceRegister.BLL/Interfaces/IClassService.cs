using AttendanceRegister.BLL.Models;

namespace AttendanceRegister.BLL.Interfaces
{
    public interface IClassService
    {
        Task<OperationResult<IEnumerable<ClassModel>>> GetAllClassesAsync();

        Task<OperationResult<IEnumerable<ClassInfoModel>>> GetClassesIncludedAsync();

        Task<OperationResult<IEnumerable<ClassInfoModel>>> GetClassesByTeacherAsync(int teacherId);

        Task<OperationResult<ClassModel>> DeleteClassByIdAsync(int id);

        Task<OperationResult<ClassModel>> UpdateClassAsync(ClassModel classModel);

        Task<OperationResult<ClassModel>> GetClassByIdAsync(int id);

        Task<OperationResult<ClassModel>> AddClassAsync(ClassModel classModel);
    }
}
