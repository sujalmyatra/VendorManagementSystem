    using Practical_24.Domain.Entities;
    using Practical_24.Domain.Enums;
    using Practical_24.Domain.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    namespace Practical_24.Domain.States
    {
        public class RentedState : IVehicleState
        {
            public VehicleStatus Status => VehicleStatus.Rented;

            public void Rent(Vehicle vehicle)
            {
                throw new InvalidOperationException("Vehicle is already rented.");
            }
            public void Return(Vehicle vehicle)
            {
                vehicle.ChangeStatus(VehicleStatus.Available);
            }
            public void SendToMaintenance(Vehicle vehicle)
            {
                vehicle.ChangeStatus(VehicleStatus.Maintenance);

            }
        }
    }
