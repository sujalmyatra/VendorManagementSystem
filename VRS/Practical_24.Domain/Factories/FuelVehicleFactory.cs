using Practical_24.Domain.EnergySources;
using Practical_24.Domain.Entities;
using Practical_24.Domain.Enums;
using Practical_24.Domain.ValueObjects;

namespace Practical_24.Domain.Factories
{
    public class FuelVehicleFactory(FuelType type, decimal capacity) : VehicleFactory
    {
        private readonly FuelType _type = type;
        private readonly decimal _capacity = capacity;

        public override Vehicle CreateVehicle(string model, Money rate, int limit, GpsCoordinate location)
        {
            var energySources = new EnergySource[]
            {
                new FuelEnergySource(_type, _capacity)
            };

            return new Vehicle(energySources, model, location, rate, limit);
        }
    }
}
