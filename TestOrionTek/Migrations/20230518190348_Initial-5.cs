using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestOrionTek.Migrations
{
    /// <inheritdoc />
    public partial class Initial5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Companies_CompanyIdCompany",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CompanyIdCompany",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CompanyIdCompany",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "IdCompany",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IdCompany",
                table: "Customers",
                column: "IdCompany");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Companies_IdCompany",
                table: "Customers",
                column: "IdCompany",
                principalTable: "Companies",
                principalColumn: "IdCompany",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Companies_IdCompany",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_IdCompany",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IdCompany",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "CompanyIdCompany",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CompanyIdCompany",
                table: "Customers",
                column: "CompanyIdCompany");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Companies_CompanyIdCompany",
                table: "Customers",
                column: "CompanyIdCompany",
                principalTable: "Companies",
                principalColumn: "IdCompany");
        }
    }
}
