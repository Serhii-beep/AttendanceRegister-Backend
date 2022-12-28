namespace Attendanceregister.DAL.Entities
{
    public class Lesson
    {
        public int Id { get; set; }
        public int SubjectClassId { get; set; }
        public string Theme { get; set; }
        public DateTime Date { get; set; }
        public virtual SubjectClass SubjectClass { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
        public Lesson()
        {
            Attendances = new List<Attendance>();
            Marks = new List<Mark>();
        }
    }
}
