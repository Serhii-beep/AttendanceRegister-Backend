using Attendanceregister.DAL.Data;
using Attendanceregister.DAL.Entities;
using Attendanceregister.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Attendanceregister.DAL.EFRepositories
{
    public class ClassEFRepository : EFRepository<Class>, IClassRepository
    {
        public ClassEFRepository(AttendanceRegisterDbContext context) : base(context)
        {
        }
    }
}
