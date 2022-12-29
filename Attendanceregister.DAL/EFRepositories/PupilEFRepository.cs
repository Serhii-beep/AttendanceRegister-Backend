using Attendanceregister.DAL.Data;
using Attendanceregister.DAL.Entities;
using Attendanceregister.DAL.Interfaces;

namespace Attendanceregister.DAL.EFRepositories
{
    public class PupilEFRepository : EFRepository<Pupil>, IPupilRepository
    {
        public PupilEFRepository(AttendanceRegisterDbContext context) : base(context)
        {
        }
    }
}
