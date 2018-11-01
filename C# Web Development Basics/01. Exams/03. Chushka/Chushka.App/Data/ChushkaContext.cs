using Chushka.App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chushka.App.Data
{
    public class ChushkaContext : DbContext
    {
        public ChushkaContext(DbContextOptions options) : base(options)
        {
        }

        public ChushkaContext()
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=SomeService;Database=ChushkaDb;Integrated Security=True");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
