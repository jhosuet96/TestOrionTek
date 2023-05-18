using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestOrionTek.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerDetails_Customers_CustomersICcustomer",
                table: "CustomerDetails");

            migrationBuilder.RenameColumn(
                name: "ICcustomer",
                table: "Customers",
                newName: "IdCustomer");

            migrationBuilder.RenameColumn(
                name: "ICcustomer",
                table: "CustomerDetails",
                newName: "IdCustomer");

            migrationBuilder.RenameColumn(
                name: "CustomersICcustomer",
                table: "CustomerDetails",
                newName: "CustomersIdCustomer");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerDetails_CustomersICcustomer",
                table: "CustomerDetails",
                newName: "IX_CustomerDetails_CustomersIdCustomer");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerDetails_Customers_CustomersIdCustomer",
                table: "CustomerDetails",
                column: "CustomersIdCustomer",
                principalTable: "Customers",
                principalColumn: "IdCustomer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerDetails_Customers_CustomersIdCustomer",
                table: "CustomerDetails");

            migrationBuilder.RenameColumn(
                name: "IdCustomer",
                table: "Customers",
                newName: "ICcustomer");

            migrationBuilder.RenameColumn(
                name: "IdCustomer",
                table: "CustomerDetails",
                newName: "ICcustomer");

            migrationBuilder.RenameColumn(
                name: "CustomersIdCustomer",
                table: "CustomerDetails",
                newName: "CustomersICcustomer");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerDetails_CustomersIdCustomer",
                table: "CustomerDetails",
                newName: "IX_CustomerDetails_CustomersICcustomer");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerDetails_Customers_CustomersICcustomer",
                table: "CustomerDetails",
                column: "CustomersICcustomer",
                principalTable: "Customers",
                principalColumn: "ICcustomer");
        }
    }
}
