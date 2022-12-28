namespace Attendanceregister.DAL.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<SubjectClass> SubjectClasses { get; set; }
        public virtual ICollection<Pupil> Pupils { get; set; }
        public Class()
        {
            SubjectClasses = new List<SubjectClass>();
            Pupils = new List<Pupil>();
        }
    }
}
