using Microsoft.EntityFrameworkCore;
using Turshia.App.Models;

namespace Turshia.App.Data
{
    public class TurshiaDbContext : DbContext
    {
        public TurshiaDbContext(DbContextOptions options) : base(options)
        {
        }

        public TurshiaDbContext()
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<TaskSector> TasksSecotors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=SomeServer;Database=TurshiaDb;Integrated Security=True");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskSector>()
                .HasKey(x => new { x.SectorId, x.TaskId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
