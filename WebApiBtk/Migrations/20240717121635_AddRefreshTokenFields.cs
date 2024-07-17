using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApiBtk.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshTokenFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a0433e4-27cc-48ee-a946-a08173d1e4ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89044cc3-2311-4eb2-8dd4-a97331bce478");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b64345c7-4a93-4574-9e7a-d1bc040634ce");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "93549d41-2ccf-487e-a88e-61bf8d5c634f", "bc46b4ec-fa6a-4e91-a0db-3308271cc809", "Editor", "EDITOR" },
                    { "a7163d55-aa2a-4fec-b6a7-a2013443bd49", "0632d0b3-24da-4579-be59-0d259756a1be", "Admin", "ADMIN" },
                    { "ea568fe3-7f9e-4cda-8f92-83138e25deb6", "4f1b4150-0e0e-4953-afd4-c3c7c2c5ef33", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93549d41-2ccf-487e-a88e-61bf8d5c634f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7163d55-aa2a-4fec-b6a7-a2013443bd49");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea568fe3-7f9e-4cda-8f92-83138e25deb6");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4a0433e4-27cc-48ee-a946-a08173d1e4ea", "27538c6c-a239-479f-badd-37588c2f6daa", "Admin", "ADMIN" },
                    { "89044cc3-2311-4eb2-8dd4-a97331bce478", "528e1057-4190-4b53-a40a-9139a6a57333", "User", "USER" },
                    { "b64345c7-4a93-4574-9e7a-d1bc040634ce", "57af9451-5224-4336-b181-7fba127f826e", "Editor", "EDITOR" }
                });
        }
    }
}
