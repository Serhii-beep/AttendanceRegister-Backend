namespace Attendanceregister.DAL.Entities
{
    public class Mark : BaseEntity
    {
        public int LessonId { get; set; }
        public int PupilId { get; set; }
        public string Value { get; set; }
        public virtual Lesson Lesson { get; set; }
        public virtual Pupil Pupil { get; set; }
    }
}
