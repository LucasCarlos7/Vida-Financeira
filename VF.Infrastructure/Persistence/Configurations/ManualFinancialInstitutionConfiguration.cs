using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VF.Core.Entities;

namespace VF.Infrastructure.Persistence.Configurations;

public class ManualFinancialInstitutionConfiguration : IEntityTypeConfiguration<ManualFinancialInstitution>
{
    public void Configure(EntityTypeBuilder<ManualFinancialInstitution> builder)
    {
        builder.Property(m => m.Notes)
            .HasMaxLength(500)
            .HasColumnType("nvarchar(500)");
    }
}
