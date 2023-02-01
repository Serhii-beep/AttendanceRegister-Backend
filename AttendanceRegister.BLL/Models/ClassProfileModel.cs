namespace AttendanceRegister.BLL.Models
{
    public class ClassProfileModel
    {
        public int Id { get; set; }
        public string ProfileName { get; set; }
        public ICollection<ClassModel> Classes { get; set; }

        public ClassProfileModel()
        {
            Classes = new List<ClassModel>();
        }
    }
}
