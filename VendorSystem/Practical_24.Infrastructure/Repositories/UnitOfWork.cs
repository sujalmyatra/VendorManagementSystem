using Practical_24.Domain.Entities;
using Practical_24.Domain.Interfaces;
using Practical_24.Infrastructure.Data;

namespace Practical_24.Infrastructure.Repositories
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public IGenericRepository<Customer> Customers { get; } = new GenericRepository<Customer>(context);
        public IGenericRepository<Vendor> Vendors { get; } = new GenericRepository<Vendor>(context);
        public IGenericRepository<Invoice> Invoices { get; } = new GenericRepository<Invoice>(context);
        public IGenericRepository<InvoiceList> InvoiceLists { get; } = new GenericRepository<InvoiceList>(context);
        public IGenericRepository<Payment> Payments { get; } = new GenericRepository<Payment>(context);

        public async Task<int> SaveChangesAsync(CancellationToken token = default)
        {
            return await context.SaveChangesAsync(token);
        }

    }
}
