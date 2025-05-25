using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VF.Core.Entities;

namespace VF.Infrastructure.Persistence.Configurations
{
    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.ToTable("CreditCards");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("uniqueidentifier");

            builder.Property(c => c.CardName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar(100)");

            builder.Property(c => c.CardFlag)
                .IsRequired()
                .HasConversion<int>()
                .HasColumnType("int");

            builder.Property(c => c.DueDay)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(c => c.MothlyLimit)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .HasColumnType("datetime2");

            builder.Property(c => c.UpdatedAt)
                .IsRequired()
                .HasColumnType("datetime2");

            builder.HasOne(c => c.Account)
                .WithMany(a => a.CreditCards)
                .HasForeignKey(c => c.AccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}