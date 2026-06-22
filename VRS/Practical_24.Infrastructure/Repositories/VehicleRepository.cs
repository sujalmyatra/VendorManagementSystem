using Microsoft.EntityFrameworkCore;
using Practical_24.Domain.Entities;
using Practical_24.Domain.Interfaces;
using Practical_24.Infrastructure.Data;

namespace Practical_24.Infrastructure.Repositories
{
    public class VehicleRepository(AppDbContext context) : GenericRepository<Vehicle>(context), IVehicleRepository
    {
        
        public async Task<Vehicle?> GetByIdWithEnergySourcesAsync(Guid id, CancellationToken token = default)
        {
            return await _context.Vehicles.Include(x => x.EnergySources).FirstOrDefaultAsync(v => v.Id == id, token);
        }
    }
}
