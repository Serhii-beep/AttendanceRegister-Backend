namespace Attendanceregister.DAL.Entities
{
    public class SubjectClass : BaseEntity
    {
        public int ClassId { get; set; }
        public int SubjectId { get; set; }
        public virtual Class Class { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
        public SubjectClass()
        {
            Lessons = new List<Lesson>();
        }
    }
}
