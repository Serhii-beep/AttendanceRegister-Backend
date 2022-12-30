using Attendanceregister.DAL;
using Attendanceregister.DAL.Data;
using Attendanceregister.DAL.Interfaces;
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
        }
    }
}
