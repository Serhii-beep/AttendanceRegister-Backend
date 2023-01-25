using Attendanceregister.DAL;
using Attendanceregister.DAL.Data;
using Attendanceregister.DAL.Interfaces;
using AttendanceRegister.BLL.Interfaces;
using AttendanceRegister.BLL.Services;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AttendanceRegister.BLL
{
    public class BllDIConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            DalDIConfiguration.ConfigureServices(services, configuration);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IPupilService, PupilService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<IMapper, Mapper>(implementationFactory =>
            {
                var profile = new AutoMapperProfile();
                var config = new MapperConfiguration(cfg => cfg.AddProfile(profile));
                return new Mapper(config);
            });
        }
    }
}
