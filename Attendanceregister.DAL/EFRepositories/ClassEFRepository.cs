using Attendanceregister.DAL.Data;
using Attendanceregister.DAL.Entities;
using Attendanceregister.DAL.Interfaces;

namespace Attendanceregister.DAL.EFRepositories
{
    internal class ClassEFRepository : EFRepository<Class>, IClassRepository
    {
        public ClassEFRepository(AttendanceRegisterDbContext context) : base(context)
        {
        }
    }
}
