using Practical_24.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Domain.Interfaces
{
    public interface IVehicleStateFactory
    {
        IVehicleState GetState(VehicleStatus status);
    }
}
