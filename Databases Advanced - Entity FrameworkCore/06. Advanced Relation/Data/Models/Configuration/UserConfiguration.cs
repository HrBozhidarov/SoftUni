using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace P01_BillsPaymentSystem.Data.Models.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                 .Property(x => x.FirstName)
                 .IsRequired()
                 .HasMaxLength(50)
                 .IsUnicode();

            builder
                 .Property(x => x.LastName)
                 .IsRequired()
                 .HasMaxLength(50)
                 .IsUnicode();

            builder
                .Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(80)
                .IsUnicode(false);

            builder
                .Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false);
        }
    }
}
