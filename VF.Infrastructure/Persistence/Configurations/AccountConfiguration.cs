using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VF.Core.Entities;

namespace VF.Infrastructure.Persistence.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .ValueGeneratedOnAdd()
            .HasColumnType("uniqueidentifier");

        builder.Property(a => a.AccountName)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnType("nvarchar(100)");

        builder.Property(a => a.AccountDescription)
            .HasMaxLength(250)
            .HasColumnType("nvarchar(250)");

        builder.Property(a => a.AccountType)
            .IsRequired()
            .HasConversion<int>()
            .HasColumnType("int");

        builder.Property(a => a.Balance)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(a => a.IsMainAccount)
            .IsRequired()
            .HasColumnType("bit");

        builder.Property(a => a.RegistrationType)
            .IsRequired()
            .HasConversion<int>()
            .HasColumnType("int");

        builder.Property(a => a.IsFiled)
            .IsRequired()
            .HasColumnType("bit");

        builder.Property(a => a.CreatedAt)
            .IsRequired()
            .HasColumnType("datetime2");

        builder.Property(a => a.UpdatedAt)
            .IsRequired()
            .HasColumnType("datetime2");

        // Relação com User (CORRETA AGORA)
        builder.HasOne(a => a.User)
            .WithMany(u => u.Accounts)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relação com FinancialInstitution (mantida)
        builder.HasOne(a => a.FinancialInstitution)
            .WithMany() // ou .WithMany(f => f.Accounts) se desejar modelar do outro lado
            .HasForeignKey(a => a.FinancialInstitutionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
