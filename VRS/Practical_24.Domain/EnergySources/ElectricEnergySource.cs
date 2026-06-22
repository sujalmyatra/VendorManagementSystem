using Practical_24.Domain.Enums;
namespace Practical_24.Domain.EnergySources
{
    public class ElectricEnergySource(int batteryPercentage) : EnergySource(EnergySourceType.Electric), IRefillable
    {
        public decimal BatteryPercentage { get; private set; } =  batteryPercentage;

        public void Refill(decimal percentage)
        {
            if (percentage < 0)
                throw new InvalidOperationException("percentage must be greater than zero");

            BatteryPercentage += percentage;

        }
    }
}
