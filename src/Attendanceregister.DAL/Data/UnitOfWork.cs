using Attendanceregister.DAL.EFRepositories;
using Attendanceregister.DAL.Interfaces;

namespace Attendanceregister.DAL.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AttendanceRegisterDbContext _context;

        public IAdminRepository AdminRepository => new AdminEFRepository(_context);

        public IClassProfileRepository ClassProfileRepository => new ClassProfileEFRepository(_context);

        public IClassRepository ClassRepository => new ClassEFRepository(_context);

        public ILessonRepository LessonRepository => new LessonEFRepository(_context);

        public IMarkRepository MarkRepository => new MarkEFRepository(_context);

        public IPupilRepository PupilRepository => new PupilEFRepository(_context);

        public ISubjectClassRepository SubjectClassRepository => new SubjectClassEFRepository(_context);

        public ISubjectRepository SubjectRepository => new SubjectEFRepository(_context);

        public ITeacherRepository TeacherRepository => new TeacherEFRepository(_context);

        public ITeacherSubjectRepository TeacherSubjectRepository => new TeacherSubjectEFRepository(_context);

        public ISectionRepository SectionRepository => new SectionEFRepository(_context);

        public UnitOfWork(AttendanceRegisterDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
