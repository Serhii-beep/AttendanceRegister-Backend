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
            CreateMap<Teacher, TeacherModel>().ReverseMap();
            CreateMap<Class, ClassModel>();
            CreateMap<ClassModel, Class>();
            CreateMap<ClassProfile, ClassProfileModel>();
            CreateMap<ClassProfileModel, ClassProfile>();
            CreateMap<PupilModel, Pupil>().ForMember(p => p.ClassId, pm => pm.MapFrom(x => x.Class.Id))
                .ForMember(p => p.Class, opt => opt.Ignore());
            CreateMap<Subject, SubjectModel>().ForMember(x => x.Teachers, opt => opt.Ignore())
                .ForMember(x => x.Classes, opt => opt.Ignore());
            CreateMap<SubjectModel, Subject>();
        }
    }
}
