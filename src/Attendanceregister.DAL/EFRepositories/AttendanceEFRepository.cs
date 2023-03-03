using Attendanceregister.DAL.Data;
using Attendanceregister.DAL.Entities;
using Attendanceregister.DAL.Interfaces;

namespace Attendanceregister.DAL.EFRepositories
{
    public class AttendanceEFRepository : EFRepository<Attendance>, IAttendanceRepository
    {
        public AttendanceEFRepository(AttendanceRegisterDbContext context) : base(context)
        {
        }
    }
}
