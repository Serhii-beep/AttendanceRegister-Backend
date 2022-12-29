using Attendanceregister.DAL.Data;
using Attendanceregister.DAL.Entities;
using Attendanceregister.DAL.Interfaces;

namespace Attendanceregister.DAL.EFRepositories
{
    public class TeacherEFRepository : EFRepository<Teacher>, ITeacherRepository
    {
        public TeacherEFRepository(AttendanceRegisterDbContext context) : base(context)
        {
        }
    }
}
