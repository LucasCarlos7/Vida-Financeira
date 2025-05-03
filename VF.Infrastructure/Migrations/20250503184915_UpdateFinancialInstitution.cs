using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VF.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFinancialInstitution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "FinancialInstitutions",
                newName: "UpdatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "FinancialInstitutions",
                newName: "UpdateAt");
        }
    }
}
