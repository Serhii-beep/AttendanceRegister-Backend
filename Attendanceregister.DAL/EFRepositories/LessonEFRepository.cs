using Attendanceregister.DAL.Data;
using Attendanceregister.DAL.Entities;
using Attendanceregister.DAL.Interfaces;

namespace Attendanceregister.DAL.EFRepositories
{
    internal class LessonEFRepository : EFRepository<Lesson>, ILessonRepository
    {
        public LessonEFRepository(AttendanceRegisterDbContext context) : base(context)
        {
        }
    }
}
