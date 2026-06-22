using Practical_24.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Practical_24.Domain.EnergySources;
using Practical_24.Domain.Enums;

namespace Practical_24.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Vehicle> Vehicles => Set<Vehicle>();
        public DbSet<EnergySource> EnergySources => Set<EnergySource>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(v => v.Id);

                entity.Property(v => v.Model).IsRequired().HasMaxLength(100);

                entity.Property(v => v.Status).HasConversion<int>().IsRequired();


                entity.OwnsOne(v => v.CurrentLocation, location =>
                {
                    location.Property(l => l.Longitude).HasColumnName("Longitude");
                    location.Property(l => l.Latitude).HasColumnName("Latitude");
                });

                entity.OwnsOne(v => v.HourlyRate, money =>
                {
                    money.Property(m => m.Amount).HasColumnName("HourlyRate").HasColumnType("18,2");
                });

                entity.Property(v => v.SpeedLimit).IsRequired();

                entity.HasMany(v => v.EnergySources)
                .WithOne(e => e.Vehicle)
                .HasForeignKey(e => e.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);

            }
                
            );

            modelBuilder.Entity<EnergySource>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Type).HasConversion<int>().IsRequired();

                entity.HasDiscriminator(e => e.Type)
                .HasValue<FuelEnergySource>(EnergySourceType.Fuel)
                .HasValue<ElectricEnergySource>(EnergySourceType.Electric);
            
            });
        }

    }
}
