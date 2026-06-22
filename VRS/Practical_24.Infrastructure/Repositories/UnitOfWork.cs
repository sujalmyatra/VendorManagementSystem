using Practical_24.Domain.Entities;
using Practical_24.Domain.Interfaces;
using Practical_24.Infrastructure.Data;

namespace Practical_24.Infrastructure.Repositories
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        private readonly AppDbContext _context = context;
        public IVehicleRepository Vehicles { get; } = new VehicleRepository(context);

        public Task<int> SaveChangesAsync(CancellationToken token = default)
        {
            return _context.SaveChangesAsync(token);
        }
        
    }
}
