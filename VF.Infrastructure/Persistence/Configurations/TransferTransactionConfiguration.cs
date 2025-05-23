using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VF.Core.Entities;

namespace VF.Infrastructure.Persistence.Configurations
{
    public class TransferTransactionConfiguration : IEntityTypeConfiguration<TransferTransaction>
    {
        public void Configure(EntityTypeBuilder<TransferTransaction> builder)
        {
            builder.ToTable("TransferTransactions");

            builder.Property(t => t.Transferred)
                .IsRequired()
                .HasColumnType("bit");

            // Relacionamento obrigatório com OriginAccount
            builder.HasOne(t => t.OriginAccount)
                .WithMany()
                .HasForeignKey("OriginAccountId")
                .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento obrigatório com DestinyAccount
            builder.HasOne(t => t.DestinyAccount)
                .WithMany()
                .HasForeignKey("DestinyAccountId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}