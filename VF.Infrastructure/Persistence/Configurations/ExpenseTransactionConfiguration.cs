using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VF.Core.Entities;

namespace VF.Infrastructure.Persistence.Configurations
{
    public class ExpenseTransactionConfiguration : IEntityTypeConfiguration<ExpenseTransaction>
    {
        public void Configure(EntityTypeBuilder<ExpenseTransaction> builder)
        {
            builder.ToTable("ExpenseTransactions");

            builder.Property(e => e.FormPayment)
                .IsRequired()
                .HasConversion<int>()
                .HasColumnType("int");

            builder.Property(e => e.PaymentCondition)
                .IsRequired()
                .HasConversion<int>()
                .HasColumnType("int");

            builder.Property(e => e.Installments)
                .HasColumnType("int");

            builder.Property(e => e.IsPaid)
                .HasColumnType("bit");

            // Relacionamento com CreditCard (opcional)
            builder.HasOne(e => e.CreditCard)
                .WithMany() // Se quiser, pode criar coleção inversa: CreditCard.ExpenseTransactions
                .HasForeignKey("CreditCardId")
                .OnDelete(DeleteBehavior.SetNull);

            // Relacionamento com Account (opcional)
            builder.HasOne(e => e.Account)
                .WithMany()
                .HasForeignKey("AccountId")
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}