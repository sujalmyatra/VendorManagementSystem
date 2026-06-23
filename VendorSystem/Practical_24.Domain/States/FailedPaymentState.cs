using Practical_24.Domain.Entities;
using Practical_24.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Domain.States
{
    public class FailedPaymentState
    : IPaymentState
    {
        public PaymentStatus Status => PaymentStatus.Failed;

        public void StartProcessing(Payment payment)
        {
            throw new InvalidOperationException("Failed payment cannot be processed again.");
        }
        public void MarkSucceeded(Payment payment)
        {
            throw new InvalidOperationException("Failed payment cannot be marked as succeeded.");
        }
        public void RegisterFailedAttempt(Payment payment)
        {
            throw new InvalidOperationException("Failed payment cannot register more attempts.");
        }
    }
}
