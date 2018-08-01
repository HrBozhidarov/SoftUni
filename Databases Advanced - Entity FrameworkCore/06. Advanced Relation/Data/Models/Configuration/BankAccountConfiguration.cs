using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace P01_BillsPaymentSystem.Data.Models.Configuration
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder
                .Property(x => x.BankName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);

            builder
               .Property(x => x.SwiftCode)
               .IsRequired()
               .IsUnicode(false)
               .HasMaxLength(20);
        }
    }
}
