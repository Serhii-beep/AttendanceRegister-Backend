using Attendanceregister.DAL.Data;
using Attendanceregister.DAL.Entities;
using Attendanceregister.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Attendanceregister.DAL.EFRepositories
{
    public class PupilEFRepository : EFRepository<Pupil>, IPupilRepository
    {
        public PupilEFRepository(AttendanceRegisterDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Pupil>> GetAllWithClasses()
        {
            return await _context.Pupils.Include(p => p.Class).ToListAsync();
        }
    }
}
