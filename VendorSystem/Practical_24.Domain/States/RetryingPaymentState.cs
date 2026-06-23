using Practical_24.Domain.Entities;
using Practical_24.Domain.Enums;

namespace Practical_24.Domain.States
{
    public class RetryingPaymentState
    : IPaymentState
    {
        public PaymentStatus Status => PaymentStatus.Retrying;

        public void StartProcessing(Payment payment)
        {
            payment.ChangeStatus(PaymentStatus.Processing);
        }
        public void MarkSucceeded(Payment payment)
        {
            throw new InvalidOperationException("Retrying payment must start processing before it can succeeded.");
        }
        public void RegisterFailedAttempt(Payment payment)
        {
            throw new InvalidOperationException("Retrying payment cannot fail again before process start.");
        }
    }
}
