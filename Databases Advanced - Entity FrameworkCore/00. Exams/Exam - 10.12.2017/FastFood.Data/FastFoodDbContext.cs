using FastFood.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Data
{
	public class FastFoodDbContext : DbContext
	{
		public FastFoodDbContext()
		{
		}

		public FastFoodDbContext(DbContextOptions options)
			: base(options)
		{
		}

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
		{
			if (!builder.IsConfigured)
			{
                builder
                     .UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
            builder.Entity<Position>(entity =>
            {
                entity.HasIndex(x => x.Name)
                      .IsUnique();
            });

            builder.Entity<Item>(entity =>
            {
                entity.HasIndex(x => x.Name)
                      .IsUnique();

                entity.HasOne(x => x.Category)
                      .WithMany(x => x.Items)
                      .HasForeignKey(x => x.CategoryId);
            });

            builder.Entity<Employee>(entity =>
            {
                entity.HasOne(x => x.Position)
                      .WithMany(x => x.Employees)
                      .HasForeignKey(x => x.PositionId);
            });

            builder.Entity<Order>(entity =>
            {
                entity.HasOne(x => x.Employee)
                      .WithMany(x => x.Orders)
                      .HasForeignKey(x => x.EmployeeId);
            });

            builder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(x => new { x.ItemId, x.OrderId });

                entity.HasOne(x => x.Order)
                      .WithMany(x => x.OrderItems)
                      .HasForeignKey(x => x.OrderId);

                entity.HasOne(x => x.Item)
                     .WithMany(x => x.OrderItems)
                     .HasForeignKey(x => x.ItemId);
            });
        }
	}
}