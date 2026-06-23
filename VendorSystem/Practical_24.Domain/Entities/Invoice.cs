using Practical_24.Domain.Common;
using Practical_24.Domain.Enums;

namespace Practical_24.Domain.Entities
{
    public class Invoice(Guid customerId,Guid vendorId) : BaseEntity
    {
        public Guid CustomerId { get; set; } = customerId;
        public Customer Customer { get; set; } = null!;

        public Guid VendorId { get; set; } = vendorId;
        public Vendor Vendor { get; set; } = null!;

        public DateTime InvoiceDate { get; set; } = DateTime.UtcNow;

        public ICollection<InvoiceList> InvoiceLists = new List<InvoiceList>();

        public InvoiceStatus Status { get; set; } = InvoiceStatus.Created;

        public Payment? Payment { get; private set; }

    }
}
