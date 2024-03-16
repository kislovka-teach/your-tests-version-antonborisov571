using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PassingTrips.Migrations
{
    /// <inheritdoc />
    public partial class AddedCities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "coordinates",
                columns: new[] { "id", "longitude", "width" },
                values: new object[,]
                {
                    { 1, 0f, 0f },
                    { 2, 0f, 50f }
                });

            migrationBuilder.InsertData(
                table: "cities",
                columns: new[] { "id", "coordinate_id", "name" },
                values: new object[,]
                {
                    { 1, 1, "Москва" },
                    { 2, 2, "Казань" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "cities",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "cities",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "coordinates",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "coordinates",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
