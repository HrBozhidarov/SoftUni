using AutoMappingObjectsExercice.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoMappingObjectsExercice.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options) 
            : base(options)
        {
        }

        public EmployeeContext()
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.Connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(e =>
            {
                e.HasOne(x => x.Manager)
                .WithMany(x => x.ManagedEmployees)
                .HasForeignKey(x => x.ManagerId);
            });
        }
    }
}
