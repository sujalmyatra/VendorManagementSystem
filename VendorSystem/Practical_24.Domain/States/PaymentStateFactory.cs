using Practical_24.Domain.Enums;

namespace Practical_24.Domain.States
{
    public sealed class PaymentStateFactory
    {
        private static Dictionary<PaymentStatus, IPaymentState> States =
            new List<IPaymentState>
            {
            new RetryingPaymentState(),
            new SucceededPaymentState(),
            new FailedPaymentState(),
            new ProcessingPaymentState(),
            new PendingPaymentState()
            }.ToDictionary(state => state.Status);

        public static IPaymentState GetState(PaymentStatus status)
        {
            if (!States.TryGetValue(status, out var state))
                throw new InvalidOperationException("Invalid state");

            return state;
        }
    }
}
