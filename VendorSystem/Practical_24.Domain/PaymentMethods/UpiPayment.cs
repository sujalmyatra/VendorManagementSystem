using Practical_24.Domain.Enums;
using Practical_24.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Domain.PaymentMethods
{
    public class UpiPayment : IPaymentMethod
    {
        public PaymentType Type => PaymentType.Upi;
    }
}
