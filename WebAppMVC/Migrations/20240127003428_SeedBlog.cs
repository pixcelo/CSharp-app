using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAppMVC.Migrations
{
    /// <inheritdoc />
    public partial class SeedBlog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Blog",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "First Blog" },
                    { 2, "Second Blog" },
                    { 3, "Third Blog" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blog",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Blog",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Blog",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
