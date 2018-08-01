using CarDealer.Model;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;

namespace CarDealer.Data
{
    public class CarDealerContext : DbContext
    {
        public CarDealerContext()
        {
        }

        public CarDealerContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Part> Parts { get; set; }

        public DbSet<PartCar> PartCars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.Connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Sale>(entity =>
            {
                entity.HasOne(x => x.Customer)
                .WithMany(x => x.Sales)
                .HasForeignKey(x => x.CustomerId);

                entity.HasOne(x => x.Car)
               .WithMany(x => x.Sales)
               .HasForeignKey(x => x.CarId);
            });

            builder.Entity<Part>(entity =>
            {
                entity.HasOne(x => x.Supplier)
                      .WithMany(x => x.Parts)
                      .HasForeignKey(x => x.SupplierId);
            });

            builder.Entity<PartCar>(entity =>
            {
                entity.HasKey(x => new { x.CarId, x.PartId });

                entity.HasOne(x => x.Part)
                      .WithMany(x => x.PartCars)
                      .HasForeignKey(x => x.PartId);

                entity.HasOne(x => x.Car)
                     .WithMany(x => x.PartCars)
                     .HasForeignKey(x => x.CarId);
            });
        }
    }
}
