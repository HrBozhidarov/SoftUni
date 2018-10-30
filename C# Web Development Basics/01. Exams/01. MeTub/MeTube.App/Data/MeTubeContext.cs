using JetBrains.Annotations;
using MeTube.App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeTube.App.Data
{
    public class MeTubeContext : DbContext
    {
        public MeTubeContext(DbContextOptions options) : base(options)
        {
        }

        public MeTubeContext()
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Tube> Tubes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=SomeServer;Database=MeTubeDb;Integrated Security=True");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
