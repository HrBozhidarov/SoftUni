using FDMC.App.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FDMC.App.Data
{
    public class FDMCContext : DbContext
    {
        public FDMCContext(DbContextOptions options) : base(options)
        {
        }

        public FDMCContext()
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Kitten> Kittens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=SomeServer;Database=FDMCDb;Integrated Security=True");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
