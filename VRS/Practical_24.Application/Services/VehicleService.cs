using Practical_24.Application.DTOs;
using Practical_24.Application.Interfaces;
using Practical_24.Domain.Entities;
using Practical_24.Domain.Enums;
using Practical_24.Domain.Factories;
using Practical_24.Domain.Interfaces;
using Practical_24.Domain.Services;
using Practical_24.Domain.ValueObjects;
using System.Net;

namespace Practical_24.Application.Services
{
    public class VehicleService(IUnitOfWork uow, VehicleTransitionService service) : IVehicleService
    {
        private readonly IUnitOfWork _uow = uow;
        private readonly IVehicleTransitionService _service = service;

        public async Task<Guid> CreateFuelVehicleAsync(CreateFuelVehicleRequest request, CancellationToken token = default)
        {
            var loaction = new GpsCoordinate(request.Latitude, request.Longitude);
            var rate = new Money(request.HourlyRate);
            var factory = new FuelVehicleFactory(request.FuelType, request.FuelCapacity);
            var vehicle = factory.CreateVehicle(request.Model, rate, request.SpeedLimit, loaction);

            await _uow.Vehicles.AddAsync(vehicle, token);
            await _uow.SaveChangesAsync();

            return vehicle.Id;
        }

        public async Task<Guid> CreateElectricVehical(CreateElectricVehicleRequest request, CancellationToken token = default)
        {
            var loaction = new GpsCoordinate(request.Latitude, request.Longitude);
            var rate = new Money(request.HourlyRate);
            var factory = new ElectricVehicleFactory(request.BatteryPercentage);
            var vehicle = factory.CreateVehicle(request.Model, rate, request.SpeedLimit, loaction);

            await _uow.Vehicles.AddAsync(vehicle, token);
            await _uow.SaveChangesAsync();

            return vehicle.Id;
        }

        public async Task<VehicleResponse> GetVehicleByIdAsync(Guid id, CancellationToken token = default)
        {
            var v = await GetVehicleOrThrowAsync(id, token);

            return MapToResponse(v);

        }

        public async Task<IReadOnlyList<VehicleResponse>> GetAllVehicleAsync(CancellationToken token)
        {
            var v = await _uow.Vehicles.GetAllAsync(token);

            return v.Select(MapToResponse).ToList();
        }
        public async Task RentVehicleAsync(Guid id, CancellationToken token)
        {
            var v = await GetVehicleOrThrowAsync(id, token);

            _service.Rent(v);
            _uow.Vehicles.Update(v);
            await _uow.SaveChangesAsync(token);
        }

        public async Task ReturnVehicleAsync(Guid id, CancellationToken token = default)
        {
            var v = await GetVehicleOrThrowAsync(id, token);
            _service.Return(v);
            _uow.Vehicles.Update(v);
            await _uow.SaveChangesAsync(token);
        }

        public async Task SendVehicleToMaintenance(Guid id, CancellationToken token = default)
        {
            var v = await GetVehicleOrThrowAsync(id, token);
            _service.SendToMaintenance(v);
            _uow.Vehicles.Update(v);
            await _uow.SaveChangesAsync(token);
        }

        public async Task UpdateVehicleLocation(Guid id, double lt, double lg, CancellationToken token = default)
        {
            var v = await GetVehicleOrThrowAsync(id, token);
            var location = new GpsCoordinate(lt, lg);

            v.UpdateLocation(location);

            _uow.Vehicles.Update(v);
            await _uow.SaveChangesAsync(token);


        }
        private async Task<Vehicle> GetVehicleOrThrowAsync(Guid id, CancellationToken token = default) 
        {
            var vehicle = await _uow.Vehicles.GetByIdAsync(id,token);
            if (vehicle is null) 
                throw new InvalidOperationException("Vehicle not found.");
            return vehicle;
        }

        public async Task RefillVehicleAsync(Guid id, EnergySourceType type, decimal amt ,CancellationToken token = default)
        {
            var v = await GetVehicleOrThrowAsync(id, token);
            v.Refill(type, amt);

            _uow.Vehicles.Update(v);
            await _uow.SaveChangesAsync(token);
        }

        public async Task DeleteVehicleAsync(Guid id, CancellationToken token = default)
        {
            var v = await GetVehicleOrThrowAsync(id, token);
            _uow.Vehicles.Delete(v);
            await _uow.SaveChangesAsync(token);
        }
        private static VehicleResponse MapToResponse(Vehicle vehicle)
        {
            return new VehicleResponse
            {
                Id = vehicle.Id,
                Model = vehicle.Model,
                HourlyRate = vehicle.HourlyRate.Amount,
                SpeedLimit = vehicle.SpeedLimit,
                Latitude = vehicle.CurrentLocation.Latitude,
                Longitude = vehicle.CurrentLocation.Longitude,
                Status = vehicle.Status
            };
        }
    }
}
