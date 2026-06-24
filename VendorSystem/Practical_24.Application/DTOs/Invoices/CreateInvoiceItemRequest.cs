
namespace Practical_24.Application.DTOs.Invoices
{
    public sealed record CreateInvoiceItemRequest(string ItemName, int Quantity, decimal Price);
}
