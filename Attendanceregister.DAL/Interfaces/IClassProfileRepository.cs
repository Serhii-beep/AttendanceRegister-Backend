using Attendanceregister.DAL.Entities;

namespace Attendanceregister.DAL.Interfaces
{
    public interface IClassProfileRepository : IRepository<ClassProfile>
    {
        Task<IEnumerable<ClassProfile>> GetAllWithClassesAsync();
    }
}
