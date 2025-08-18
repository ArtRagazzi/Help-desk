using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "address", "email", "first_name", "last_name", "password", "phone", "role" },
                values: new object[,]
                {
                    { 1, "123 Main Street", "artur@admin.com", "Artur", "Admin", "123456", "1999238-9992", 1 },
                    { 2, "123 Main Street", "artur@normal.com", "Artur", "Normal", "123456", "1999238-9992", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
