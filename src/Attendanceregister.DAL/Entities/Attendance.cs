namespace Attendanceregister.DAL.Entities
{
    public class Attendance : BaseEntity
    {
        public int LessonId { get; set; }
        public int PupilId { get; set; }
        public string Note { get; set; }
        public virtual Lesson Lesson { get; set; }
        public virtual Pupil Pupil { get; set; }
    }
}
