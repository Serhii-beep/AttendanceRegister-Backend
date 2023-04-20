namespace Attendanceregister.DAL.Entities
{
    public class Pupil : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public int ClassId { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public virtual Class Class { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
        public Pupil()
        {
            Marks = new List<Mark>();
        }

    }
}
