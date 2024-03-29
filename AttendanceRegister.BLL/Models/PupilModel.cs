﻿namespace AttendanceRegister.BLL.Models
{
    public class PupilModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public ClassModel Class { get; set; }
    }

}