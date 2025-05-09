using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VF.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateCreditCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "CreditCards");

            migrationBuilder.AddColumn<int>(
                name: "DueDay",
                table: "CreditCards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDay",
                table: "CreditCards");

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "CreditCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
