using Attendanceregister.DAL.Entities;

namespace Attendanceregister.DAL.Interfaces
{
    public interface IPupilRepository : IRepository<Pupil>
    {
        Task<IEnumerable<Pupil>> GetAllWithClasses();
    }
}
