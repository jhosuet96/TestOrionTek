using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestOrionTek.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerDetails_CustomerDetailsIdCustomerDetail",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerDetailsIdCustomerDetail",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerDetailsIdCustomerDetail",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "CustomersICcustomer",
                table: "CustomerDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ICcustomer",
                table: "CustomerDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDetails_CustomersICcustomer",
                table: "CustomerDetails",
                column: "CustomersICcustomer");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerDetails_Customers_CustomersICcustomer",
                table: "CustomerDetails",
                column: "CustomersICcustomer",
                principalTable: "Customers",
                principalColumn: "ICcustomer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerDetails_Customers_CustomersICcustomer",
                table: "CustomerDetails");

            migrationBuilder.DropIndex(
                name: "IX_CustomerDetails_CustomersICcustomer",
                table: "CustomerDetails");

            migrationBuilder.DropColumn(
                name: "CustomersICcustomer",
                table: "CustomerDetails");

            migrationBuilder.DropColumn(
                name: "ICcustomer",
                table: "CustomerDetails");

            migrationBuilder.AddColumn<int>(
                name: "CustomerDetailsIdCustomerDetail",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerDetailsIdCustomerDetail",
                table: "Customers",
                column: "CustomerDetailsIdCustomerDetail");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerDetails_CustomerDetailsIdCustomerDetail",
                table: "Customers",
                column: "CustomerDetailsIdCustomerDetail",
                principalTable: "CustomerDetails",
                principalColumn: "IdCustomerDetail");
        }
    }
}
