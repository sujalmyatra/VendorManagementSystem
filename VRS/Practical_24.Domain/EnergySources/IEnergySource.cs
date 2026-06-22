using System;
using System.Collections.Generic;
using System.Text;
using Practical_24.Domain.Enums;

namespace Practical_24.Domain.EnergySources
{
    public interface IEnergySource
    {
        EnergySourceType Type { get; }
    }
}
