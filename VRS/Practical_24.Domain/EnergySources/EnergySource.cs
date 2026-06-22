using Practical_24.Domain.Entities;
using Practical_24.Domain.Enums;


namespace Practical_24.Domain.EnergySources
{
    public abstract class EnergySource : BaseEntity, IEnergySource
    {
        
        public EnergySourceType Type { get; private set; }
        public Vehicle Vehicle { get; private set; } = null!;
        public Guid VehicleId { get; set; }
        protected EnergySource() {

        }

        protected EnergySource(EnergySourceType type)
        {
            Type = type;
        }

        
    }
}
