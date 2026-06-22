using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Domain.Enums
{
    public enum PaymentStatus
    {
        Pending = 1,
        Processing = 2,
        Retrying = 3,
        Succeeded = 4,
        Failed = 5
    }
}
