using Practical_24.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Application.DTOs
{
    public sealed class VehicleResponse
    {
        public Guid Id { get; set; }

        public string Model { get; set; } = string.Empty;

        public decimal HourlyRate { get; set; }

        public int SpeedLimit { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public VehicleStatus Status { get; set; }
    }
}
