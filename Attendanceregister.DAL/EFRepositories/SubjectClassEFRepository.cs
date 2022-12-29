using Attendanceregister.DAL.Data;
using Attendanceregister.DAL.Entities;
using Attendanceregister.DAL.Interfaces;

namespace Attendanceregister.DAL.EFRepositories
{
    internal class SubjectClassEFRepository : EFRepository<SubjectClass>, ISubjectClassRepository
    {
        public SubjectClassEFRepository(AttendanceRegisterDbContext context) : base(context)
        {
        }
    }
}
