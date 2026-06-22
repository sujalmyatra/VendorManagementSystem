using Practical_24.Domain.Enums;
using Practical_24.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Domain.Factories
{
    public class VehicleStateFactory(IEnumerable<IVehicleState> states) : IVehicleStateFactory
    {
        public Dictionary<VehicleStatus, IVehicleState> _states = states.ToDictionary(states => states.Status);

        public IVehicleState GetState(VehicleStatus status)
        {
            return  _states.TryGetValue(status, out var state)? 
            state : 
            throw new InvalidOperationException($"No state found for status: {status}");
            
            
        }

    }
}
