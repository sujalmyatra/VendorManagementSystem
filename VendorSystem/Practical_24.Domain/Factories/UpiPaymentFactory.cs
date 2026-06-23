using Practical_24.Domain.Enums;
using Practical_24.Domain.PaymentMethods;

namespace Practical_24.Domain.Factories
{
    public class UpiPaymentFactory : IPaymentMethodFactory
    {
        public PaymentType Type => PaymentType.Upi;

        public IPaymentMethod Create()
        {
            return new UpiPayment();
        }
    }
}
