using Practical_24.Application.DTOs.Payments;

namespace Practical_24.Application.DTOs.Invoices
{
    public sealed record OrderResponse
    (
        Guid InvoiceId,Guid CustomerId, Guid VendorId,
        DateTime InvoiceDate, List<InvoiceItemResponse> Items,
        PaymentResponse Payment
    );
}
