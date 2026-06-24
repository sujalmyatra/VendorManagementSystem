using Microsoft.EntityFrameworkCore;
using Practical_24.Domain.Common;
using Practical_24.Domain.Entities;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace Practical_24.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        private const string user = "system";
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Payment> Payments => Set<Payment>();
        public DbSet<Invoice> Invoices => Set<Invoice>();
        public DbSet<Customer> Cusotmers => Set<Customer>();
        public DbSet<Vendor> Vendors => Set<Vendor>();
        public DbSet<InvoiceList> InvoiceLists => Set<InvoiceList>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureCustomer(modelBuilder);
            ConfigureVendor(modelBuilder);
            ConfigureInvoice(modelBuilder);
            ConfigurePayment(modelBuilder);
            ConfigureInvoiceList(modelBuilder);

        }

        public override Task<int> SaveChangesAsync(CancellationToken token = default)
        {
            ApplyAuditAndSoftDelete();

            return base.SaveChangesAsync(token);
        }
       
        private void ApplyAuditAndSoftDelete()
        {
            var entries = ChangeTracker.Entries<AuditableSoftDeleteEntity>();

            foreach(var entry in entries) 
            { 
                if(entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = user;
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }

                if(entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedBy = user;
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }

                if(entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                    entry.Entity.UpdatedBy = user;
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
            }
        }

        public static void ConfigureCustomer(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.HasKey(x => x.Id);

                entity.Property(x => x.Name).IsRequired().HasMaxLength(100);

                entity.Property(x => x.Email).IsRequired().HasMaxLength(100);

                entity.Property(x => x.CreatedBy).IsRequired().HasMaxLength(100);

                entity.Property(x => x.UpdatedBy).IsRequired().HasMaxLength(100);

                entity.HasQueryFilter(x => !x.IsDeleted);

                entity.HasMany(x => x.Invoices)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }
        public static void ConfigureVendor(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.ToTable("Vendor");

                entity.HasKey(x => x.Id);

                entity.Property(x => x.Name).IsRequired().HasMaxLength(100);

                entity.Property(x => x.Email).IsRequired().HasMaxLength(100);

                entity.Property(x => x.CreatedBy).IsRequired().HasMaxLength(100);

                entity.Property(x => x.UpdatedBy).IsRequired().HasMaxLength(100);

                entity.HasQueryFilter(x => !x.IsDeleted);

                entity.HasMany(x => x.Invoices)
                .WithOne(x => x.Vendor)
                .HasForeignKey(x => x.VendorId)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }
        public static void ConfigureInvoice(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoce");
                entity.HasKey(x => x.Id);

                entity.Property(x => x.InvoiceDate).IsRequired();

                entity.HasMany(x => x.InvoiceLists)
                .WithOne(x => x.Invoice)
                .HasForeignKey(x => x.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(x => x.Payment)
                .WithOne(x => x.Invoice)
                .HasForeignKey<Payment>(x => x.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade);
            });
        }
        public static void ConfigureInvoiceList(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceList>(entity =>
            {
                entity.ToTable("InvoiceLists");

                entity.HasKey(x => x.Id);

                entity.Property(x => x.ItemName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(x => x.Quantity)
                    .IsRequired();

                entity.Property(x => x.Price)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");
            });
        }
        public static void ConfigurePayment(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payments");

                entity.HasKey(x => x.Id);

                entity.Property(x => x.PaymentType)
                    .IsRequired();

                entity.Property(x => x.Status)
                    .IsRequired();

                entity.Property(x => x.Amount)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                entity.Property(x => x.FailedAttempt)
                    .IsRequired();

                entity.Property(x => x.PaidAt);
            });
        }
    }
}
