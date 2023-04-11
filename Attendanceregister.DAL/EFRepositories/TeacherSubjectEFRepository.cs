using Attendanceregister.DAL.Data;
using Attendanceregister.DAL.Entities;
using Attendanceregister.DAL.Interfaces;

namespace Attendanceregister.DAL.EFRepositories
{
    public class TeacherSubjectEFRepository : EFRepository<TeacherSubject>, ITeacherSubjectRepository
    {
        public TeacherSubjectEFRepository(AttendanceRegisterDbContext context) : base(context)
        {
        }
    }
}
