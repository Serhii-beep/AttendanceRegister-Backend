using Attendanceregister.DAL.Data;
using Attendanceregister.DAL.Entities;
using Attendanceregister.DAL.Interfaces;

namespace Attendanceregister.DAL.EFRepositories
{
    public class SectionEFRepository : EFRepository<Section>, ISectionRepository
    {
        public SectionEFRepository(AttendanceRegisterDbContext contex) : base(contex) { }
    }
}
