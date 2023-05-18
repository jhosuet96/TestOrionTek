using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestOrionTek.Migrations
{
    /// <inheritdoc />
    public partial class Initial7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerDetails_Customers_CustomersIdCustomer",
                table: "CustomerDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Companies_CompanyIdCompany",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CompanyIdCompany",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_CustomerDetails_CustomersIdCustomer",
                table: "CustomerDetails");

            migrationBuilder.DropColumn(
                name: "CompanyIdCompany",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomersIdCustomer",
                table: "CustomerDetails");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IdCompany",
                table: "Customers",
                column: "IdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDetails_IdCustomer",
                table: "CustomerDetails",
                column: "IdCustomer");

            migrationBuilder.AddForeignKey(
                name: "IdCustomer",
                table: "CustomerDetails",
                column: "IdCustomer",
                principalTable: "Customers",
                principalColumn: "IdCustomer",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "IdCompany",
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
                name: "FK_CustomerDetails_Customers_IdCustomer",
                table: "CustomerDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Companies_IdCompany",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_IdCompany",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_CustomerDetails_IdCustomer",
                table: "CustomerDetails");

            migrationBuilder.AddColumn<int>(
                name: "CompanyIdCompany",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomersIdCustomer",
                table: "CustomerDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CompanyIdCompany",
                table: "Customers",
                column: "CompanyIdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDetails_CustomersIdCustomer",
                table: "CustomerDetails",
                column: "CustomersIdCustomer");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerDetails_Customers_CustomersIdCustomer",
                table: "CustomerDetails",
                column: "CustomersIdCustomer",
                principalTable: "Customers",
                principalColumn: "IdCustomer");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Companies_CompanyIdCompany",
                table: "Customers",
                column: "CompanyIdCompany",
                principalTable: "Companies",
                principalColumn: "IdCompany",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
