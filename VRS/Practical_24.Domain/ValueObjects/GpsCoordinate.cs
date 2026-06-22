using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Domain.ValueObjects
{
    public sealed class GpsCoordinate(double latitude, double longitude)
    {
        public double Latitude { get; private set; } = latitude;
        public double Longitude { get; private set;  } = longitude;
    }
}
