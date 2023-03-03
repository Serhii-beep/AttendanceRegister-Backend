using Attendanceregister.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Attendanceregister.DAL
{
    public class DalDIConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("AttendanceRegister");
            services.AddDbContext<AttendanceRegisterDbContext>(options => options.UseSqlServer(connection));
        }
    }
}
