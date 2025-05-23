using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VF.Core.Entities;

namespace VF.Infrastructure.Persistence.Configurations
{
    public class IncomeTransactionConfiguration : IEntityTypeConfiguration<IncomeTransaction>
    {
        public void Configure(EntityTypeBuilder<IncomeTransaction> builder)
        {
            builder.ToTable("IncomeTransactions");

            builder.Property(i => i.Received)
                .IsRequired()
                .HasColumnType("bit");

            // Relacionamento obrigatório com Account
            builder.HasOne(i => i.Account)
                .WithMany()
                .HasForeignKey("AccountId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}