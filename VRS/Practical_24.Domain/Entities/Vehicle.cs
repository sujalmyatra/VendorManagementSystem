using Practical_24.Domain.EnergySources;
using Practical_24.Domain.Enums;
using Practical_24.Domain.Interfaces;
using Practical_24.Domain.States;
using Practical_24.Domain.ValueObjects;

namespace Practical_24.Domain.Entities
{
    public sealed class Vehicle(IEnumerable<EnergySource> energySources, string model, GpsCoordinate currentLocation, Money rate, int limit ) : BaseEntity
    {
        public List<EnergySource> EnergySources =  energySources.ToList();

        public VehicleStatus Status { get; private set; } = VehicleStatus.Available;

        public string Model { get; private set; } = model;
        public GpsCoordinate CurrentLocation { get; private set; } = currentLocation;
        public Money HourlyRate { get; private set; } = rate;
        public int SpeedLimit { get; private set; } = limit;



        public void ChangeStatus(VehicleStatus status)
        {
            Status = status;
        }

        public void UpdateLocation(GpsCoordinate newLocation)
        {
            CurrentLocation = newLocation;
        }
        public void TrackSpeed(int currentSpeed)
        {
            if(currentSpeed > SpeedLimit)
            {
                //Event
            }
        }

        public void Refill(EnergySourceType type,decimal amount)
        {
            var energySource = _energySources.FirstOrDefault(source => source.Type == type);

            if (energySource is null)
                throw new InvalidOperationException($"{type} energy source in not available for this vehicle.");

            if(energySource is not IRefillable refillable)
            {
                throw new InvalidOperationException($"{type} energy source cannot be refilled.");
            }

            refillable.Refill(amount);
        }
       
    }
}
