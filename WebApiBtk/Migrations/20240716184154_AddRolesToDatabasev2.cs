using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApiBtk.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesToDatabasev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46b0011d-911a-47ba-adec-763558321e2b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "caf09860-4dbc-4a3c-9eb6-7336a3cd16f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb564188-889a-43c7-928b-84c3ca4c32d8");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46b0011d-911a-47ba-adec-763558321e2b", null, "User", "USER" },
                    { "caf09860-4dbc-4a3c-9eb6-7336a3cd16f1", null, "Editor", "EDITOR" },
                    { "cb564188-889a-43c7-928b-84c3ca4c32d8", null, "Admin", "ADMIN" }
                });
        }
    }
}
