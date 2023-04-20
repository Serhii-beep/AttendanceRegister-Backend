namespace Attendanceregister.DAL.Entities
{
    public class Section : BaseEntity
    {
        public int Term { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
        public Section()
        {
            Lessons = new List<Lesson>();
        }
    }
}
