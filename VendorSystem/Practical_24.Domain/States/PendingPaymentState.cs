using Practical_24.Domain.Entities;
using Practical_24.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Domain.States
{
    public class PendingPaymentState : IPaymentState
    {
        public PaymentStatus Status => PaymentStatus.Pending;

        public void StartProcessing(Payment payment)
        {
            payment.ChangeStatus(PaymentStatus.Processing);
        }
        public void MarkSucceeded(Payment payment)
        {
            throw new Exception("Pending Payment not succeeded");
        }
        public void RegisterFailedAttempt(Payment payment)
        {
            throw new InvalidOperationException("Pending payment cannot register failure before processing starts.");
        }
    }
}
