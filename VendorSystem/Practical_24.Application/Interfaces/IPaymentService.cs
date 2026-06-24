using Practical_24.Application.DTOs.Payments;
using Practical_24.Domain.Entities;

namespace Practical_24.Application.Interfaces
{
    public interface IPaymentService
    {
        Task<Payment> ProcessPaymentAsync(Payment payment, int fail, CancellationToken token = default);
    }
}
