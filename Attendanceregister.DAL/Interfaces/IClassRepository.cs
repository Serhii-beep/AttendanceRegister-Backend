using Attendanceregister.DAL.Entities;

namespace Attendanceregister.DAL.Interfaces
{
    public interface IClassRepository : IRepository<Class>
    {
        Task<IEnumerable<Class>> GetAllWithProfilesAndPupilsAsync();

        Task<Class> GetByIdWithProfileAsync(int id);
    }
}
