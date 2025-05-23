using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VF.Core.Entities;

namespace VF.Infrastructure.Persistence.Configurations
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Members");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(m => m.FullName)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("nvarchar(150)");

            builder.Property(m => m.DateBirth)
                .IsRequired()
                .HasColumnType("datetime2");

            builder.Property(m => m.Relationship)
                .IsRequired()
                .HasConversion<int>()
                .HasColumnType("int");
        }
    }
}