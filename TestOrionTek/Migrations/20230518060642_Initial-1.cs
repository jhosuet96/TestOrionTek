using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestOrionTek.Migrations
{
    /// <inheritdoc />
    public partial class Initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    IdCompany = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCompany = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.IdCompany);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDetails",
                columns: table => new
                {
                    IdCustomerDetail = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDetails", x => x.IdCustomerDetail);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ICcustomer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyIdCompany = table.Column<int>(type: "int", nullable: true),
                    CustomerDetailsIdCustomerDetail = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ICcustomer);
                    table.ForeignKey(
                        name: "FK_Customers_Companies_CompanyIdCompany",
                        column: x => x.CompanyIdCompany,
                        principalTable: "Companies",
                        principalColumn: "IdCompany");
                    table.ForeignKey(
                        name: "FK_Customers_CustomerDetails_CustomerDetailsIdCustomerDetail",
                        column: x => x.CustomerDetailsIdCustomerDetail,
                        principalTable: "CustomerDetails",
                        principalColumn: "IdCustomerDetail");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CompanyIdCompany",
                table: "Customers",
                column: "CompanyIdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerDetailsIdCustomerDetail",
                table: "Customers",
                column: "CustomerDetailsIdCustomerDetail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "CustomerDetails");
        }
    }
}
