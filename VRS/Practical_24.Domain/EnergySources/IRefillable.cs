using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Domain.EnergySources
{
    public interface IRefillable
    {
        void Refill(decimal amount);
    }
}
