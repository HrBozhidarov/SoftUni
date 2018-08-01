using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;
using System;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext(DbContextOptions<SalesContext> options)
             : base(options)
        {
        }

        public SalesContext()
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=SomeServer;Database=Sales;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Sale>(e =>
            {
                e.Property(x => x.Date).HasDefaultValueSql("GETDATE()");

                e.HasOne(p => p.Product)
                .WithMany(s => s.Sales)
                .HasForeignKey(p => p.ProductId);

                e.HasOne(c => c.Customer)
               .WithMany(s => s.Sales)
               .HasForeignKey(c => c.CustomerId);

                e.HasOne(st => st.Store)
               .WithMany(s => s.Sales)
               .HasForeignKey(st => st.StoreId);
            });

            //builder.Entity<Product>(e =>
            //{
            //    e.Property(x => x.Name).HasMaxLength(50).IsUnicode();
            //});

            //builder.Entity<Customer>(e =>
            //{
            //    e.Property(x => x.Name).HasMaxLength(100).IsUnicode();
            //    e.Property(x => x.Email).HasMaxLength(80).IsUnicode(false);
            //});

            //builder.Entity<Store>(e =>
            //{
            //    e.Property(x => x.Name).HasMaxLength(80).IsUnicode();
            //});
        }
    }
}
