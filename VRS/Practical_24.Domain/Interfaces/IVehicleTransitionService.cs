using Practical_24.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Domain.Interfaces
{
    public interface IVehicleTransitionService
    {
        void Rent(Vehicle vehicle);
        void Return(Vehicle vehicle);
        void SendToMaintenance(Vehicle vehicle);
    }
}
