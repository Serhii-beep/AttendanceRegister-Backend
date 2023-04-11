using Attendanceregister.DAL.Data;
using Attendanceregister.DAL.Entities;
using Attendanceregister.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Attendanceregister.DAL.EFRepositories
{
    public class EFRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected AttendanceRegisterDbContext _context;

        protected DbSet<T> DbSet { get; set; }

        public EFRepository(AttendanceRegisterDbContext context)
        {
            _context = context;
            DbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            if(_context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            DbSet.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            Delete(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
            DbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
