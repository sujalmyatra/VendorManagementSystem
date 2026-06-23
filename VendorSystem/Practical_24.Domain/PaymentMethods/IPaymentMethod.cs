using Practical_24.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Domain.PaymentMethods
{
    public interface IPaymentMethod
    {
        PaymentType Type { get; }
    }
}
