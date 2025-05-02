using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VF.Core.Entities;

namespace VF.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .ValueGeneratedOnAdd()
            .HasColumnType("int");

        builder.Property(u => u.Cpf)
            .IsRequired()
            .HasMaxLength(11)
            .HasColumnType("nvarchar(11)");

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnType("nvarchar(100)");

        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnType("nvarchar(100)");

        builder.Property(u => u.PasswordHash)
            .IsRequired()
            .HasMaxLength(256)
            .HasColumnType("nvarchar(256)");

        builder.Property(u => u.Phone)
            .HasMaxLength(20)
            .HasColumnType("nvarchar(20)");

        builder.Property(u => u.PhotoUrl)
            .HasMaxLength(250)
            .HasColumnType("nvarchar(250)");

        builder.Property(u => u.CreatedAt)
            .IsRequired()
            .HasColumnType("datetime2");

        builder.Property(u => u.UpdatedAt)
            .IsRequired()
            .HasColumnType("datetime2");

        builder.HasMany(u => u.Accounts)
            .WithOne(a => a.User)
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}