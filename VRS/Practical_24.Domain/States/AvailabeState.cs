using Practical_24.Domain.Entities;
using Practical_24.Domain.Enums;
using Practical_24.Domain.Interfaces;

namespace Practical_24.Domain.States
{
    public class AvailabeState : IVehicleState
    {
        public VehicleStatus Status => VehicleStatus.Available;

        public void Rent(Vehicle vehicle)
        {
            vehicle.ChangeStatus(VehicleStatus.Rented);
        }
        public void Return(Vehicle vehicle)
        {
            throw new InvalidOperationException("Available vehicle cannot be returned.");
        }

        public void SendToMaintenance(Vehicle vehicle) 
        {
            vehicle.ChangeStatus(VehicleStatus.Maintenance);
        }
    }
}
