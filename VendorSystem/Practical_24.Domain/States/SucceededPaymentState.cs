using Practical_24.Domain.Entities;
using Practical_24.Domain.Enums;

namespace Practical_24.Domain.States
{
    public class SucceededPaymentState
    : IPaymentState
    {
        public PaymentStatus Status => PaymentStatus.Succeeded;

        public void StartProcessing(Payment payment)
        {
            throw new InvalidOperationException("Succeeded payment cannot be processed again.");
        }
        public void MarkSucceeded(Payment payment)
        {
            throw new InvalidOperationException("Payment is already succeeded.");
        }
        public void RegisterFailedAttempt(Payment payment)
        {
            throw new InvalidOperationException("Succeeded payment cannot register failure.");
        }
    }
}
