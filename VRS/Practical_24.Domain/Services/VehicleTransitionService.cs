using Practical_24.Domain.Entities;
using Practical_24.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Domain.Services
{
    public class VehicleTransitionService(IVehicleStateFactory factory) : IVehicleTransitionService
    {
        private IVehicleStateFactory _factory = factory;

        public void Rent(Vehicle vehicle)
        {
            var currentState = _factory.GetState(vehicle.Status);
            currentState.Rent(vehicle);
        }

        public void Return(Vehicle vehicle)
        {
            var currentState = _factory.GetState(vehicle.Status);
            currentState.Return(vehicle);
        }

        public void SendToMaintenance(Vehicle vehicle)
        {
            var currentState = _factory.GetState(vehicle.Status);
            currentState.SendToMaintenance(vehicle);
        }
    }
}
