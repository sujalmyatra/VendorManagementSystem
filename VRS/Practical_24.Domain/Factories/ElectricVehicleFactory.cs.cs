using Practical_24.Domain.EnergySources;
using Practical_24.Domain.Entities;
using Practical_24.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Domain.Factories
{
    public class ElectricVehicleFactory(int per) : VehicleFactory
    {
        private readonly int BatteryPercentage = per;

        public override Vehicle CreateVehicle(string model, Money rate, int limit, GpsCoordinate location)
        {
            var energySource = new EnergySource[]
            {
                new ElectricEnergySource(BatteryPercentage)
            };

            return new Vehicle(energySource, model, location, rate, limit);
        }
    }
}
