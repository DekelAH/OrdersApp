using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrdersApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefreshTokenExpiration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpirationDateTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: new Guid("1298c7c7-7355-47c9-9a6c-20fae1235e04"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 24, 17, 35, 56, 303, DateTimeKind.Local).AddTicks(1304));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: new Guid("bde74418-44bd-4bbc-a4cb-fcd1087010a9"),
                column: "OrderDate",
                value: new DateTime(2023, 8, 24, 17, 35, 56, 303, DateTimeKind.Local).AddTicks(1384));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshTokenExpirationDateTime",
                table: "AspNetUsers");

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
    }
}
