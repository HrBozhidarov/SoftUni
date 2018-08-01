using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace P01_BillsPaymentSystem.Data.Models.Configuration
{
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder
                .HasIndex(x => new { x.BankAccountId, x.CreditCardId })
                .IsUnique();

            builder
                .Property(x => x.Type)
                .HasConversion(c => c.ToString(),
                 c => (Type)Enum.Parse(typeof(Type), c));

            builder
                .HasOne(x => x.BankAccount)
                .WithOne(x => x.PaymentMethod)
                .HasForeignKey<PaymentMethod>(x => x.BankAccountId);

            builder
                .HasOne(x => x.CreditCard)
                .WithOne(x => x.PaymentMethod)
                .HasForeignKey<PaymentMethod>(x => x.CreditCardId);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.PaymentMethods)
                .HasForeignKey(x => x.UserId);
        }
    }
}
