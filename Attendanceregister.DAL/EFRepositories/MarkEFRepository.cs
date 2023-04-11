using Attendanceregister.DAL.Data;
using Attendanceregister.DAL.Entities;
using Attendanceregister.DAL.Interfaces;

namespace Attendanceregister.DAL.EFRepositories
{
    public class MarkEFRepository : EFRepository<Mark>, IMarkRepository
    {
        public MarkEFRepository(AttendanceRegisterDbContext context) : base(context)
        {
        }
    }
}
