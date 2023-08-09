using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrdersApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTotalPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "OrderItems",
                type: "float",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemID",
                keyValue: new Guid("31143d81-5b90-4cf6-bcf6-13be124a8aba"),
                column: "TotalPrice",
                value: 12000000.0);

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemID",
                keyValue: new Guid("5d30db88-6ec9-49d3-ac09-b4a926fede2c"),
                column: "TotalPrice",
                value: 3400000.0);

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemID",
                keyValue: new Guid("80192c06-c6da-4f14-acc5-5aaa944f0006"),
                column: "TotalPrice",
                value: 42000000.0);

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemID",
                keyValue: new Guid("8ae24980-58a4-49ed-8c65-5d3aca583801"),
                column: "TotalPrice",
                value: 10400000.0);

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemID",
                keyValue: new Guid("b6f94083-1c2d-49ca-930b-bca3cc1ee53b"),
                column: "TotalPrice",
                value: 700000.0);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: new Guid("1298c7c7-7355-47c9-9a6c-20fae1235e04"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 8, 10, 32, 12, 856, DateTimeKind.Local).AddTicks(5898));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: new Guid("bde74418-44bd-4bbc-a4cb-fcd1087010a9"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 8, 10, 32, 12, 856, DateTimeKind.Local).AddTicks(5976));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "OrderItems");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: new Guid("1298c7c7-7355-47c9-9a6c-20fae1235e04"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 8, 10, 24, 0, 171, DateTimeKind.Local).AddTicks(3246));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: new Guid("bde74418-44bd-4bbc-a4cb-fcd1087010a9"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 8, 10, 24, 0, 171, DateTimeKind.Local).AddTicks(3335));
        }
    }
}
