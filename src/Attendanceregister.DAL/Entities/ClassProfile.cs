namespace Attendanceregister.DAL.Entities
{
    public class ClassProfile : BaseEntity
    {
        public string ProfileName { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public ClassProfile()
        {
            Classes = new List<Class>();
        }
    }
}
