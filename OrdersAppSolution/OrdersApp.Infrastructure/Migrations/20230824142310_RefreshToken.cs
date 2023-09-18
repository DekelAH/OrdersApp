using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrdersApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: new Guid("1298c7c7-7355-47c9-9a6c-20fae1235e04"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 24, 17, 23, 10, 356, DateTimeKind.Local).AddTicks(6644));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: new Guid("bde74418-44bd-4bbc-a4cb-fcd1087010a9"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 24, 17, 23, 10, 356, DateTimeKind.Local).AddTicks(6722));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: new Guid("1298c7c7-7355-47c9-9a6c-20fae1235e04"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 23, 23, 6, 55, 279, DateTimeKind.Local).AddTicks(2459));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: new Guid("bde74418-44bd-4bbc-a4cb-fcd1087010a9"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 23, 23, 6, 55, 279, DateTimeKind.Local).AddTicks(2536));
        }
    }
}
