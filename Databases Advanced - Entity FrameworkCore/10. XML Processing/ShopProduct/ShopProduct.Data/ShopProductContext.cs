using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using ShopProduct.Model;
using System;

namespace ShopProduct.Data
{
    public class ShopProductContext : DbContext
    {
        public ShopProductContext()
        {
        }

        public ShopProductContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<CategoryProduct> CategoryProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.Conncetion);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CategoryProduct>(entity =>
            {
                entity.HasKey(x => new { x.CategoryId, x.ProductId });

                entity.HasOne(x => x.Category)
                      .WithMany(x => x.CategoryProducts)
                      .HasForeignKey(x => x.CategoryId);

                entity.HasOne(x => x.Product)
                      .WithMany(x => x.Categories)
                      .HasForeignKey(x => x.ProductId);
            });

            builder.Entity<Product>(entity =>
            {
                entity.HasOne(x => x.Buyer)
                      .WithMany(x => x.BoughtProducts)
                      .HasForeignKey(x => x.BuyerId);

                entity.HasOne(x => x.Seller)
                      .WithMany(x => x.SoldProducts)
                      .HasForeignKey(x => x.SellerId);
            });
        }
    }
}
