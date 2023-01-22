using Attendanceregister.DAL.Entities;
using AttendanceRegister.BLL.Models;
using AutoMapper;

namespace AttendanceRegister.BLL
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Admin, AdminModel>();
            CreateMap<Pupil, PupilModel>();
            CreateMap<Teacher, TeacherModel>();
            CreateMap<Class, ClassModel>();
        }
    }
}
