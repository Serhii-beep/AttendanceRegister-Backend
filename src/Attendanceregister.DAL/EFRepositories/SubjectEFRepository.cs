using Attendanceregister.DAL.Data;
using Attendanceregister.DAL.Entities;
using Attendanceregister.DAL.Interfaces;

namespace Attendanceregister.DAL.EFRepositories
{
    public class SubjectEFRepository : EFRepository<Subject>, ISubjectRepository
    {
        public SubjectEFRepository(AttendanceRegisterDbContext context) : base(context)
        {
        }
    }
}
