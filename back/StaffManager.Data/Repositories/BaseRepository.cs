using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManager.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDBContext context;

        public BaseRepository(ApplicationDBContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync() =>
         await context.Set<TEntity>().ToListAsync();

        public IQueryable<TEntity> AsQueryable() => 
            context.Set<TEntity>().AsQueryable();

        public async Task<TEntity> GetByIdAsync(int id) =>
            await context.Set<TEntity>().FindAsync(id);

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
