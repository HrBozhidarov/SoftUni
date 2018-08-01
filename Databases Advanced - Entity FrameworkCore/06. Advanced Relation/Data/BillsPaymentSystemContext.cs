using Microsoft.EntityFrameworkCore;
using P01_BillsPaymentSystem.Data.DataSeed;
using P01_BillsPaymentSystem.Data.Models;
using P01_BillsPaymentSystem.Data.Models.Configuration;

namespace P01_BillsPaymentSystem.Data 
{
    public class BillsPaymentSystemContext : DbContext
    {
        public BillsPaymentSystemContext()
        {
        }

        public BillsPaymentSystemContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    //.UseLazyLoadingProxies()
                    .UseSqlServer(Configuration.Connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CreditCardConfiguration());

            modelBuilder.ApplyConfiguration(new BankAccountConfiguration());

            modelBuilder.ApplyConfiguration(new PaymentMethodConfiguration());

            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.Entity<User>().HasData(new UserSeed().Seed());

            modelBuilder.Entity<CreditCard>().HasData(new CreditCardSeed().Seed());

            modelBuilder.Entity<BankAccount>().HasData(new BankAccountSeed().Seed());

            modelBuilder.Entity<PaymentMethod>().HasData(new PaymentMethodSeed().Seed());
        }
    }
}
