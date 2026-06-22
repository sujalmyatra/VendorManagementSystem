using Practical_24.Domain.Entities;
using Practical_24.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Domain.Interfaces
{
    public interface IVehicleState
    {
        VehicleStatus Status { get; }

        void Rent(Vehicle vehicle);
        void Return(Vehicle vehicle);
        void SendToMaintenance(Vehicle vehicle);

    }
}
