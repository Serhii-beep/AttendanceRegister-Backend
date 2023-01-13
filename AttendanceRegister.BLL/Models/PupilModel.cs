namespace AttendanceRegister.BLL.Models
{
    public class PupilModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public int ClassId { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
