namespace SoftJail.Data
{
	using Microsoft.EntityFrameworkCore;
    using SoftJail.Data.Models;

    public class SoftJailDbContext : DbContext
	{
		public SoftJailDbContext()
		{
		}

		public SoftJailDbContext(DbContextOptions options)
			: base(options)
		{
		}

        public DbSet<Cell> Cells { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Mail> Mails { get; set; }

        public DbSet<Prisoner> Prisoners { get; set; }

        public DbSet<Officer> Officers { get; set; }

        public DbSet<OfficerPrisoner> OfficersPrisoners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder
					.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
            builder.Entity<Prisoner>(e =>
            {
                e.HasOne(x => x.Cell)
                .WithMany(x => x.Prisoners)
                .HasForeignKey(x => x.CellId);

            });

            builder.Entity<Mail>(e =>
            {
                e.HasOne(x => x.Prisoner)
                .WithMany(x => x.Mails)
                .HasForeignKey(x => x.PrisonerId);

            });

            builder.Entity<Officer>(e =>
            {
                e.HasOne(x => x.Department)
                .WithMany(x => x.Officers)
                .HasForeignKey(x => x.DepartmentId);

            });

            builder.Entity<Cell>(e =>
            {
                e.HasOne(x => x.Department)
                .WithMany(x => x.Cells)
                .HasForeignKey(x => x.DepartmentId);

            });

            builder.Entity<OfficerPrisoner>(e =>
            {
                e.HasKey(x => new { x.OfficerId, x.PrisonerId });

                e.HasOne(x => x.Prisoner)
                .WithMany(x => x.PrisonerOfficers)
                .HasForeignKey(x => x.PrisonerId);

                e.HasOne(x => x.Officer)
                .WithMany(x => x.OfficerPrisoners)
                .HasForeignKey(x => x.OfficerId);

            });
        }
	}
}