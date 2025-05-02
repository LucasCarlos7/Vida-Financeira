using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VF.Core.Entities;

namespace VF.Infrastructure.Persistence.Configurations;

public class AutomaticFinancialInstitutionConfiguration : IEntityTypeConfiguration<AutomaticFinancialInstitution>
{
    public void Configure(EntityTypeBuilder<AutomaticFinancialInstitution> builder)
    {
        builder.Property(a => a.ClientId)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnType("nvarchar(100)");

        builder.Property(a => a.ClientSecret)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnType("nvarchar(100)");

        builder.Property(a => a.ApiEndpoint)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnType("nvarchar(200)");

        builder.Property(a => a.AccessToken)
            .HasMaxLength(1000)
            .HasColumnType("nvarchar(1000)");

        builder.Property(a => a.TokenExpiration)
            .HasColumnType("datetime2");
    }
}
