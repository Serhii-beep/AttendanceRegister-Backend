using Attendanceregister.DAL.Data;
using Attendanceregister.DAL.Entities;
using Attendanceregister.DAL.Interfaces;

namespace Attendanceregister.DAL.EFRepositories
{
    internal class AdminEFRepository : EFRepository<Admin>, IAdminRepository
    {
        public AdminEFRepository(AttendanceRegisterDbContext context) : base(context)
        {
        }
    }
}
