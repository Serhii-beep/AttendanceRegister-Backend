﻿namespace AttendanceRegister.BLL.Models
{
    public class SubjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TeacherModel> Teachers { get; set; }
    }
}
