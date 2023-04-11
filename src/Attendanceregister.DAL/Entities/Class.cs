namespace Attendanceregister.DAL.Entities
{
    public class Class : BaseEntity
    {
        public string Name { get; set; }
        public int ClassProfileId { get; set; }
        public int TeacherId { get; set; }
        public virtual ClassProfile ClassProfile { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<SubjectClass> SubjectClasses { get; set; }
        public virtual ICollection<Pupil> Pupils { get; set; }
        public Class()
        {
            SubjectClasses = new List<SubjectClass>();
            Pupils = new List<Pupil>();
        }
    }
}
