using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using PandaWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandaWebApp.Data
{
    public class PandaContext : DbContext
    {
        public PandaContext(DbContextOptions options) : base(options)
        {
        }

        public PandaContext()
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Package> Packages { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=SomeServer;Database=PandaDb;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Package>()
            .HasOne(p => p.Receipt)
            .WithOne(b => b.Package)
            .HasForeignKey<Receipt>(b => b.PackageId)
            .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
