using Attendanceregister.DAL.Data;
using Attendanceregister.DAL.Entities;
using Attendanceregister.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Attendanceregister.DAL.EFRepositories
{
    public class ClassProfileEFRepository : EFRepository<ClassProfile>, IClassProfileRepository
    {
        public ClassProfileEFRepository(AttendanceRegisterDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ClassProfile>> GetAllWithClassesAsync()
        {
            return await _context.ClassProfiles.Include(cp => cp.Classes).ToListAsync();
        }
    }
}
