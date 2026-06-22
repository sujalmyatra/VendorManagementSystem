using Practical_24.Domain.Entities;
using Practical_24.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Domain.Factories
{
    public abstract class VehicleFactory
    {
        public abstract Vehicle CreateVehicle(string model, Money rate, int limit, GpsCoordinate location);
    }
}
