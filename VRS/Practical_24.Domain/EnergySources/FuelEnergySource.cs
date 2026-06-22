using Practical_24.Domain.Enums;

namespace Practical_24.Domain.EnergySources
{
    public class FuelEnergySource(FuelType fuelType, decimal tankCapacity) : EnergySource(EnergySourceType.Fuel), IRefillable
    {
        public FuelType FuelType { get; private set; } = fuelType;
        public decimal CurrentFuel { get; private set; }
        public decimal TankCapacity { get; private set; } = tankCapacity;

        public void Refill(decimal quentity)
        {
            if (CurrentFuel + quentity > TankCapacity)
                throw new InvalidOperationException("Fuel tank capacity exceeded");
            CurrentFuel += quentity;
        }

    }
}
