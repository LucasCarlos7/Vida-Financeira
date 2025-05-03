using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VF.Core.Entities;

namespace VF.Infrastructure.Persistence.Configurations;

public class FinancialInstitutionConfiguration : IEntityTypeConfiguration<FinancialInstitution>
{
    public void Configure(EntityTypeBuilder<FinancialInstitution> builder)
    {
        builder.ToTable("FinancialInstitutions");

        builder.HasKey(f => f.Id);

        builder.Property(f => f.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnType("nvarchar(100)");

        builder.Property(f => f.PhotoUrl)
            .HasMaxLength(250)
            .HasColumnType("nvarchar(250)");

        builder.Property(f => f.CreatedAt)
            .IsRequired()
            .HasColumnType("datetime2");

        builder.Property(f => f.UpdatedAt)
            .IsRequired()
            .HasColumnType("datetime2");
    }

}