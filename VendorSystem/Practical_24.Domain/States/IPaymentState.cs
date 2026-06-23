using Practical_24.Domain.Entities;
using Practical_24.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Domain.States
{
    public interface IPaymentState
    {
        PaymentStatus Status { get; }
        void StartProcessing(Payment payment);
        void MarkSucceeded(Payment payment);
        void RegisterFailedAttempt(Payment payment);

    }
}
