// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
// using VF.Core.Entities;

// namespace VF.Infrastructure.Persistence.Configurations
// {
//     public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
//     {
//         public void Configure(EntityTypeBuilder<Transaction> builder)
//         {
//             builder.ToTable("Transactions");

//             builder.HasKey(t => t.Id);

//             builder.Property(t => t.Id)
//                 .IsRequired()
//                 .HasColumnType("uniqueidentifier");

//             builder.Property(t => t.TransactionValue)
//                 .IsRequired()
//                 .HasColumnType("decimal(18,2)");

//             builder.Property(t => t.Description)
//                 .HasMaxLength(250)
//                 .HasColumnType("nvarchar(100)");

//             builder.Property(t => t.Date)
//                 .IsRequired()
//                 .HasColumnType("datetime2");

//             // Relacionamento com Category (opcional)
//             builder.HasOne(t => t.Category)
//                 .WithMany()
//                 .HasForeignKey("CategoryId")  // Shadow property se não tiver na entidade
//                 .OnDelete(DeleteBehavior.SetNull);

//                 // Relacionamento com Category (opcional)
//             builder.HasOne(t => t.Subcategory)
//                 .WithMany()
//                 .HasForeignKey("SubcategoryId")  // Shadow property se não tiver na entidade
//                 .OnDelete(DeleteBehavior.SetNull);

//             // Relacionamento com Member (opcional)
//             builder.HasOne(t => t.Member)
//                 .WithMany()
//                 .HasForeignKey("MemberId")
//                 .OnDelete(DeleteBehavior.SetNull);

//             // Relacionamento muitos-para-muitos com Tag
//             builder.HasMany(t => t.Tags)
//                 .WithMany()
//                 .UsingEntity(j => j.ToTable("TransactionTags"));
//         }
//     }
// }