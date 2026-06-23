using Practical_24.Domain.Enums;
using Practical_24.Domain.PaymentMethods;


namespace Practical_24.Domain.Factories
{
    public class CashPaymentFactory : IPaymentMethodFactory
    {
        public PaymentType Type => PaymentType.Cash;
        public IPaymentMethod Create()
        {
            return new CashPayment();
        }
    }
}
