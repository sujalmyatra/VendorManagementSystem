using Practical_24.Domain.Enums;
using Practical_24.Domain.PaymentMethods;

namespace Practical_24.Domain.Factories
{
    public interface IPaymentMethodFactory
    {
        PaymentType Type { get; }
        IPaymentMethod Create();
    }
}
