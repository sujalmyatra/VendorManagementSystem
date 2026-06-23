using Practical_24.Domain.Entities;
using Practical_24.Domain.Enums;
using Practical_24.Domain.Exceptions;

namespace Practical_24.Domain.States
{
    public class ProcessingPaymentState
    : IPaymentState
    {
        public PaymentStatus Status => PaymentStatus.Processing;

        public void StartProcessing(Payment payment)
        {
            throw new InvalidOperationException("Already started processing");
        }
        public void MarkSucceeded(Payment payment)
        {
            payment.ChangeStatus(PaymentStatus.Succeeded);
            payment.SetPaidAt(DateTime.UtcNow);
        }
        public void RegisterFailedAttempt(Payment payment)
        {
            payment.IncreaseFailedAttempt();

            if(payment.HasReachedMaxLimit())
            {
                payment.ChangeStatus(PaymentStatus.Failed);
                throw new PaymentFailedException("Payment Failed");
            }
        }
    }
}
