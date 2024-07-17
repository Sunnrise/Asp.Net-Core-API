using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApiBtk.Migrations
{
    /// <inheritdoc />
    public partial class Many_To_One_Relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3bd3b6a5-3cdd-4eaa-b6c1-848a5b37d095", "63e1e1af-57cc-4621-9c8d-dea7976c8f61", "Admin", "ADMIN" },
                    { "cae72b56-8476-4fe6-abc8-845fb2ef10db", "4faf63ad-802b-46fa-ad58-7b143edb44f0", "User", "USER" },
                    { "e301de30-3511-457c-aa69-286c5db827a9", "531d20d6-3519-4569-8185-9bfc3c5fb88d", "Editor", "EDITOR" }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_CategoryId",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bd3b6a5-3cdd-4eaa-b6c1-848a5b37d095");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cae72b56-8476-4fe6-abc8-845fb2ef10db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e301de30-3511-457c-aa69-286c5db827a9");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Books");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "51382c0c-c8fd-4716-834e-f3aede86af8f", "acc7d71e-a16f-4fad-9397-d513ce08a49f", "Admin", "ADMIN" },
                    { "6b174b52-3507-4ce6-aff2-9fff38446029", "8bfa8ca0-ac54-4198-9db7-40dbf32bcc61", "User", "USER" },
                    { "d389edc9-e738-43e3-aec5-1ed8bba61912", "fa3f0870-042c-4d07-91c2-0c8e49669f2a", "Editor", "EDITOR" }
                });
        }
    }
}
