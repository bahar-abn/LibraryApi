using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedlibraryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_libraryAPI",
                table: "libraryAPI");

            migrationBuilder.RenameTable(
                name: "libraryAPI",
                newName: "libraries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_libraries",
                table: "libraries",
                column: "Id");

            migrationBuilder.InsertData(
                table: "libraries",
                columns: new[] { "Id", "Amount", "Author", "Name" },
                values: new object[,]
                {
                    { 1, 10, "Elif Shafak", "40 Rules of Love" },
                    { 2, 15, "Florence Scovel Shinn", "Your word is your wand" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_libraries",
                table: "libraries");

            migrationBuilder.DeleteData(
                table: "libraries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "libraries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "libraries",
                newName: "libraryAPI");

            migrationBuilder.AddPrimaryKey(
                name: "PK_libraryAPI",
                table: "libraryAPI",
                column: "Id");
        }
    }
}
