using Practical_24.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practical_24.Domain.Entities
{
    public class InvoiceList(Guid id, string name, int quantity, decimal price) : BaseEntity

    {
        public Guid InvoiceId { get; private set; } = id;
        public Invoice Invoice { get; private set; } = null!;
        public string ItemName { get; private set; } = name;
        public int Quantity { get; private set; } = quantity;
        public decimal Price { get; private set; } = price;
    }
}
