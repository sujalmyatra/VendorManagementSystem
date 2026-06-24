using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Application.DTOs.Invoices
{
    public sealed record InvoiceItemResponse
    (
        Guid Id, string ItemName, int Quantity, decimal Price, decimal Total
    );
}
