namespace PetClinic.Data
{
    using Microsoft.EntityFrameworkCore;
    using PetClinic.Models;

    public class PetClinicContext : DbContext
    {
        public PetClinicContext() { }

        public PetClinicContext(DbContextOptions options)
            :base(options) { }

        public DbSet<Animal> Animals { get; set; }

        public DbSet<Procedure> Procedures { get; set; }

        public DbSet<Passport> Passports { get; set; }

        public DbSet<ProcedureAnimalAid> ProceduresAnimalAids { get; set; }

        public DbSet<AnimalAid> AnimalAids { get; set; }

        public DbSet<Vet> Vets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Procedure>(entity =>
            {
                entity.HasOne(x => x.Animal)
                      .WithMany(x => x.Procedures)
                      .HasForeignKey(x => x.AnimalId);

                entity.HasOne(x => x.Vet)
                     .WithMany(x => x.Procedures)
                     .HasForeignKey(x => x.VetId);
            });

            builder.Entity<ProcedureAnimalAid>(e =>
            {
                e.HasKey(x => new { x.AnimalAidId, x.ProcedureId });

                e.HasOne(x => x.Procedure)
                .WithMany(x => x.ProcedureAnimalAids)
                .HasForeignKey(x => x.ProcedureId);

                e.HasOne(x => x.AnimalAid)
                .WithMany(x => x.AnimalAidProcedures)
                .HasForeignKey(x => x.AnimalAidId);
            });
        }
    }
}
