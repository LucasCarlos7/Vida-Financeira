using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VF.Core.Entities;

public class ExpenseTransactionConfiguration : IEntityTypeConfiguration<ExpenseTransaction>
{
    public void Configure(EntityTypeBuilder<ExpenseTransaction> builder)
    {
        builder.ToTable("ExpenseTransactions");

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

        builder.Property(t => t.FormPayment)
            .IsRequired()
            .HasConversion<int>()
            .HasColumnType("int");

        builder.Property(t => t.PaymentCondition)
            .IsRequired()
            .HasConversion<int>()
            .HasColumnType("int");

        builder.Property(t => t.Installments)
            .HasColumnType("int");

        builder.Property(t => t.IsPaid)
            .HasColumnType("bit");

        // Relacionamentos corretos:
        builder.HasOne(t => t.Account)
            .WithMany()
            .HasForeignKey(t => t.AccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.CreditCard)
            .WithMany()
            .HasForeignKey(t => t.CreditCardId);

        builder.HasOne(t => t.Category)
            .WithMany()
            .HasForeignKey(t => t.CategoryId);

        builder.HasOne(t => t.Subcategory)
            .WithMany()
            .HasForeignKey(t => t.SubcategoryId);

        builder.HasOne(t => t.Member)
            .WithMany()
            .HasForeignKey(t => t.MemberId);
    }
}