using Practical_24.Domain.Entities;

namespace Practical_24.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(Guid id, CancellationToken token = default);

        Task<IEnumerable<T>> GetAllAsync(CancellationToken token = default);

        Task AddAsync(T entity, CancellationToken token = default);
        void Update(T entity);
        void Delete(T entity);
    }
}
