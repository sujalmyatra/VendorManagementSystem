using Practical_24.Domain.Enums;
using Practical_24.Domain.PaymentMethods;

namespace Practical_24.Domain.Factories
{
    public class PaymentMethodFactoryProvider
    {
        private readonly Dictionary<PaymentType, IPaymentMethodFactory> _factories;

        public PaymentMethodFactoryProvider(List<IPaymentMethodFactory> factories)
        {
            _factories = factories.ToDictionary(factory => factory.Type);
        }

        public IPaymentMethod Create(PaymentType type)
        {
            if (!_factories.TryGetValue(type, out var factory))
                throw new Exception($"No Payment method factory for {type}");
            return factory.Create();
        }
    }
}