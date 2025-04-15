using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VF.Core.Entities;

namespace VF.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.Id)
            .ValueGeneratedOnAdd()
            .HasColumnType("int");

        builder.Property<string>("Cpf")
            .IsRequired()
            .HasColumnType("nvarchar(max)");

        builder.Property<DateTime>("CreatedAt")
            .HasColumnType("datetime2");

        builder.Property<string>("Email")
            .IsRequired()
            .HasColumnType("nvarchar(30)");

        builder.Property<string>("Name")
            .IsRequired()
            .HasColumnType("nvarchar(100)");

        builder.Property<string>("PasswordHash")
            .IsRequired()
            .HasColumnType("nvarchar(50)");

        builder.Property<string>("Phone")
            .IsRequired()
            .HasColumnType("nvarchar(20)");

        builder.Property<string>("PhotoUrl")
            .HasColumnType("nvarchar(max)");

        builder.Property<DateTime>("UpdateAt")
            .HasColumnType("datetime2");

        builder.HasKey("Id");

        builder.ToTable("Users");
    }

}