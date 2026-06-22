using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Domain.ValueObjects
{
    public sealed class Money(decimal amount)
    {
        public decimal Amount { get; private set; } = amount;
    }
}
