using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Application.Events
{
    public class OrderSucceededEventArgs : EventArgs
    {
        public Guid InvoiceId { get; }
        public Guid PaymentId { get; }
        public decimal Amount { get; }

        public OrderSucceededEventArgs(Guid invoiceId, Guid paymentId, decimal amount)
        {
            InvoiceId = invoiceId;
            PaymentId = paymentId;
            Amount = amount;
        }
    }
}
