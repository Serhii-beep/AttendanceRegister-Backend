namespace Attendanceregister.DAL.Entities
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
        public virtual ICollection<SubjectClass> SubjectClasses { get; set; }
        public Subject()
        {
            TeacherSubjects = new List<TeacherSubject>();
            SubjectClasses = new List<SubjectClass>();
        }
    }
}
