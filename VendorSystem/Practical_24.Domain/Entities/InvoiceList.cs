using Practical_24.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Domain.Entities
{
    public class InvoiceList : BaseEntity

    {
        public Guid InvoiceId { get; private set; }
        public Invoice Invoice { get; private set; } = null!;
        public string ItemName { get; private set; } = string.Empty;
        public int Quantity { get; private set; } 
        public decimal Price { get; private set; } 
    }
}
