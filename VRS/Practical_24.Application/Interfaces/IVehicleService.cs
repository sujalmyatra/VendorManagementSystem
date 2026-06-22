using Practical_24.Application.DTOs;
using Practical_24.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Application.Interfaces
{
    public interface IVehicleService
    {
        Task<Guid> CreateFuelVehicleAsync(
        CreateFuelVehicleRequest request,
        CancellationToken token = default);

        Task<Guid> CreateElectricVehicleAsync(
            CreateElectricVehicleRequest request,
            CancellationToken token = default);

        Task<IReadOnlyList<VehicleResponse>> GetAllVehiclesAsync(
        CancellationToken token = default);

        Task<VehicleResponse> GetVehicleById(Guid id, CancellationToken tokrn = default);

        Task RentVehicleAsync(Guid id, CancellationToken token = default);
        Task ReturnVehicleAsync(Guid id, CancellationToken token = default);
        Task SendVehicleToMaintenanceAsync(Guid id, CancellationToken token = default);

        Task UpdateVehicleLocation(Guid id, double latitude, double longitude,  CancellationToken token = default);

        Task RefillVehicleAsync(Guid id, EnergySourceType type,decimal amount, CancellationToken token = default);

        Task DeleteVehicleAsync(Guid id, CancellationToken token = default);
    }
}
