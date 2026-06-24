
using Practical_24.Domain.Entities;

namespace Practical_24.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Customer> Customers { get; }
        IGenericRepository<Vendor> Vendors { get; }
        IGenericRepository<Invoice> Invoices { get; }
        IGenericRepository<InvoiceList> InvoiceLists { get; }
        IGenericRepository<Payment> Payments { get; }

        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}
