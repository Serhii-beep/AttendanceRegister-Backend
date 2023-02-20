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
            CreateMap<ClassProfile, ClassProfileModel>();
            CreateMap<PupilModel, Pupil>().ForMember(p => p.ClassId, pm => pm.MapFrom(x => x.Class.Id))
                .ForMember(p => p.Class, opt => opt.Ignore());
            CreateMap<Class, ClassInfoModel>().ForMember(cm => cm.ProfileName, c => c.MapFrom(x => x.ClassProfile.ProfileName))
                .ForMember(cm => cm.NumberOfPupils, c => c.MapFrom(x => x.Pupils.Count));
        }
    }
}
