namespace AttendanceRegister.BLL.Models
{
    public class ClassModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassProfileId { get; set; }
        public int TeacherId { get; set; }
    }
}
