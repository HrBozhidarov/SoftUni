using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) 
            : base(options)
        {
        }

        public HospitalContext()
        {
        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<PatientMedicament> Prescriptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=SomeServer;Database=Hospital;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Visitation>(e =>
            {
                e.HasOne(v => v.Patient)
                .WithMany(p => p.Visitations)
                .HasForeignKey(p => p.PatientId);
            });

            builder.Entity<Visitation>(e =>
            {
                e.HasOne(p => p.Patient)
                .WithMany(v => v.Visitations)
                .HasForeignKey(p => p.PatientId);
            });

            builder.Entity<PatientMedicament>(e =>
            {
                e.HasKey(ck => new { ck.PatientId, ck.MedicamentId });

                e.HasOne(p => p.Patient)
                .WithMany(pm => pm.Prescriptions)
                .HasForeignKey(p => p.PatientId);

                e.HasOne(m => m.Medicament)
                .WithMany(pm => pm.Prescriptions)
                .HasForeignKey(m => m.MedicamentId);
            });
        }
    }
}
