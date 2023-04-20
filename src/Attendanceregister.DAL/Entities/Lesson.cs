namespace Attendanceregister.DAL.Entities
{
    public class Lesson : BaseEntity
    {
        public int SubjectClassId { get; set; }
        public string Theme { get; set; }
        public DateTime Date { get; set; }
        public bool IsFinal { get; set; }
        public bool IsSemester { get; set; }
        public bool IsAnnual { get; set; }
        public int SectionId { get; set; }
        public virtual SubjectClass SubjectClass { get; set; }
        public virtual Section Section { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
        public Lesson()
        {
            Marks = new List<Mark>();
        }
    }
}
