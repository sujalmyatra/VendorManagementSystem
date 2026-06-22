    using Practical_24.Domain.Entities;
    using Practical_24.Domain.Enums;
    using Practical_24.Domain.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    namespace Practical_24.Domain.States
    {
        public class MaintenanceState : IVehicleState
        {
            public VehicleStatus Status => VehicleStatus.Maintenance;

            public void Rent(Vehicle vehicle)
            {
                throw new InvalidOperationException("Vehicle under maintenance cannot be rented.");
            }
            public void Return(Vehicle vehicle)
            {
                throw new InvalidOperationException("Maintenance vehicle cannot be returned.");
            }
            public void SendToMaintenance(Vehicle vehicle)
            {
                throw new InvalidOperationException("Vehicle is already under maintenance.");
            }
        }
    }
