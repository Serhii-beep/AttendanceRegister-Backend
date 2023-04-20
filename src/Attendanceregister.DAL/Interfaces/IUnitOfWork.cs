namespace Attendanceregister.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IAdminRepository AdminRepository { get; }

        IClassProfileRepository ClassProfileRepository { get; }

        IClassRepository ClassRepository { get; }

        ILessonRepository LessonRepository { get; }

        IMarkRepository MarkRepository { get; }

        IPupilRepository PupilRepository { get; }

        ISubjectClassRepository SubjectClassRepository { get; }

        ISubjectRepository SubjectRepository { get; }

        ITeacherRepository TeacherRepository { get; }

        ITeacherSubjectRepository TeacherSubjectRepository { get; }

        ISectionRepository SectionRepository { get; }

        Task SaveAsync();
    }
}
