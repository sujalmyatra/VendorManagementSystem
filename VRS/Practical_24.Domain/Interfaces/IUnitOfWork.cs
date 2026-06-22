
using Practical_24.Domain.Entities;

namespace Practical_24.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IVehicleRepository Vehicles { get; }
        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}
