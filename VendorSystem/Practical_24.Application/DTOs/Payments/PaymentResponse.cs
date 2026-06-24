using Practical_24.Domain.Enums;
namespace Practical_24.Application.DTOs.Payments
{
    public sealed record PaymentResponse
    (
        Guid Id, PaymentType Type,
        PaymentStatus Status,
        decimal Amount,
        int FailedAttempts,
        DateTime? PaidAt
    );
}
