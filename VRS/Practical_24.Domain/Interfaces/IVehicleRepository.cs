using Practical_24.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Domain.Interfaces
{
    public interface IVehicleRepository : IGenericRepository<Vehicle>
    {
        Task<Vehicle?> GetByIdWithEnergySourcesAsync(Guid id, CancellationToken token = default);
    }
}
