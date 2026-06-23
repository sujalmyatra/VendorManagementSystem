using Practical_24.Domain.Common;
using Practical_24.Domain.Enums;
using Practical_24.Domain.States;

namespace Practical_24.Domain.Entities
{
    public class Payment(Guid invoiceId, PaymentType paymentType, decimal amt) : BaseEntity
    {
        private const int MaxAttempts = 6;

        public Guid InvoiceId { get; private set; } = invoiceId;
        public Invoice Invoice { get; private set; } = null!;

        public PaymentType PaymentType { get; private set; } = paymentType;

        public decimal Amount { get; private set; } = amt;
        public PaymentStatus Status { get; private set; } = PaymentStatus.Pending;
        public int FailedAttempt { get; private set; } = 0;
        public DateTime? PaidAt { get; private set; }

        public void StartProcessing()
        {
            var state = PaymentStateFactory.GetState(Status);
            state.StartProcessing(this);
        }
        public void MarkSucceeded()
        {
            var state = PaymentStateFactory.GetState(Status);
            state.MarkSucceeded(this);
        }

        public void RegisterFailedAttempt()
        {
            var state = PaymentStateFactory.GetState(Status);
            state.RegisterFailedAttempt(this);
        }

        public TimeSpan GetNextRetryDelay()
        {
            if (FailedAttempt <= 0)
                return TimeSpan.Zero;
            if (FailedAttempt <= MaxAttempts)
                return TimeSpan.Zero;

            int delay = 10;

            for (int i = 1; i < FailedAttempt; i++)
            {
                delay *= 2;
            }

            return TimeSpan.FromSeconds(delay);
        }

        internal void ChangeStatus(PaymentStatus status)
        {
            Status = status;
        }

        internal void IncreaseFailedAttempt()
        {
            FailedAttempt++;
        }

        internal void SetPaidAt(DateTime paidAt)
        {
            PaidAt = paidAt;
        }

        internal bool HasReachedMaxLimit()
        {
            return FailedAttempt >= MaxAttempts;
        }
    }
}