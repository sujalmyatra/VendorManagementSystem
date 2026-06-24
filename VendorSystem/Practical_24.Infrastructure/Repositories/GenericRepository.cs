using Practical_24.Domain.Interfaces;
using Practical_24.Domain.Entities;
using Practical_24.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Practical_24.Domain.Common;

namespace Practical_24.Infrastructure.Repositories
{
    public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context = context;
        private readonly DbSet<T> _dbSet = context.Set<T>();

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken token = default)
        {
            return await _dbSet.FindAsync(id, token);
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken token = default) 
        {
            return await _dbSet.AsNoTracking().ToListAsync(token);
        }

        public async Task AddAsync(T entity, CancellationToken token = default) 
        {
            await _dbSet.AddAsync(entity, token);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
