using Practical_24.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Application.DTOs.Invoices
{
    public sealed record CreateOrderRequest
    (
        Guid CustomerId, Guid VendorId,
        PaymentType Type, List<CreateInvoiceItemRequest> Items,
        int FailuresBeforeSucceess
    );
    
}
