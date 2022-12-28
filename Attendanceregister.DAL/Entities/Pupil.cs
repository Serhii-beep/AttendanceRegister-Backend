namespace Attendanceregister.DAL.Entities
{
    public class Pupil
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int ClassId { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual Class Class { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
        public Pupil()
        {
            Attendances = new List<Attendance>();
            Marks = new List<Mark>();
        }

    }
}
