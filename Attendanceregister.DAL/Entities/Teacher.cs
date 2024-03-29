﻿namespace Attendanceregister.DAL.Entities
{
    public class Teacher : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
        public Teacher()
        {
            TeacherSubjects = new List<TeacherSubject>();
        }
    }
}
