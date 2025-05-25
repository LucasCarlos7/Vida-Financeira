using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VF.Core.Entities;

public class TransferTransactionConfiguration : IEntityTypeConfiguration<TransferTransaction>
{
    public void Configure(EntityTypeBuilder<TransferTransaction> builder)
    {
        builder.ToTable("TransferTransactions");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .ValueGeneratedOnAdd()
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.TransactionValue)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(t => t.Description)
            .IsRequired()
            .HasMaxLength(250)
            .HasColumnType("nvarchar(250)");

        builder.Property(t => t.Date)
            .IsRequired()
            .HasColumnType("datetime2");

        builder.Property(t => t.Transferred)
            .IsRequired()
            .HasColumnType("bit");

        // Relacionamento com OriginAccount
        builder.HasOne(t => t.OriginAccount)
            .WithMany()
            .HasForeignKey(t => t.OriginAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relacionamento com DestinyAccount
        builder.HasOne(t => t.DestinyAccount)
            .WithMany()
            .HasForeignKey(t => t.DestinyAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.Member)
            .WithMany()
            .HasForeignKey(t => t.MemberId);
    }
}