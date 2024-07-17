using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApiBtk.Migrations
{
    /// <inheritdoc />
    public partial class Categories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "51382c0c-c8fd-4716-834e-f3aede86af8f", "acc7d71e-a16f-4fad-9397-d513ce08a49f", "Admin", "ADMIN" },
                    { "6b174b52-3507-4ce6-aff2-9fff38446029", "8bfa8ca0-ac54-4198-9db7-40dbf32bcc61", "User", "USER" },
                    { "d389edc9-e738-43e3-aec5-1ed8bba61912", "fa3f0870-042c-4d07-91c2-0c8e49669f2a", "Editor", "EDITOR" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Computer Science" },
                    { 2, "Network" },
                    { 3, "Database management" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51382c0c-c8fd-4716-834e-f3aede86af8f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b174b52-3507-4ce6-aff2-9fff38446029");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d389edc9-e738-43e3-aec5-1ed8bba61912");

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
    }
}
