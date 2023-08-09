using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrdersApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemID", "OrderID", "ProductName", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("31143d81-5b90-4cf6-bcf6-13be124a8aba"), new Guid("1298c7c7-7355-47c9-9a6c-20fae1235e04"), "Razor Mouse", 5000, 2400.0 },
                    { new Guid("5d30db88-6ec9-49d3-ac09-b4a926fede2c"), new Guid("bde74418-44bd-4bbc-a4cb-fcd1087010a9"), "Samsung PC Screen", 1000, 3400.0 },
                    { new Guid("80192c06-c6da-4f14-acc5-5aaa944f0006"), new Guid("1298c7c7-7355-47c9-9a6c-20fae1235e04"), "Razor Keyboard", 5000, 8400.0 },
                    { new Guid("8ae24980-58a4-49ed-8c65-5d3aca583801"), new Guid("bde74418-44bd-4bbc-a4cb-fcd1087010a9"), "ASUS Laptop", 1000, 10400.0 },
                    { new Guid("b6f94083-1c2d-49ca-930b-bca3cc1ee53b"), new Guid("bde74418-44bd-4bbc-a4cb-fcd1087010a9"), "HyperX Headphones", 500, 1400.0 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "CustomerName", "OrderDate", "OrderNumber", "TotalAmount" },
                values: new object[,]
                {
                    { new Guid("1298c7c7-7355-47c9-9a6c-20fae1235e04"), "Jane Mole", new DateTime(2023, 8, 8, 10, 24, 0, 171, DateTimeKind.Local).AddTicks(3246), "ORD_0001", 42.200000000000003 },
                    { new Guid("bde74418-44bd-4bbc-a4cb-fcd1087010a9"), "Chris Jankins", new DateTime(2023, 8, 8, 10, 24, 0, 171, DateTimeKind.Local).AddTicks(3335), "ORD_0002", 22.199999999999999 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
