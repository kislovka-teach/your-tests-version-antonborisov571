using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PassingTrips.Migrations
{
    /// <inheritdoc />
    public partial class FixedTripsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "arrival_city_id",
                table: "trips",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "departure_city_id",
                table: "trips",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_trips_arrival_city_id",
                table: "trips",
                column: "arrival_city_id");

            migrationBuilder.CreateIndex(
                name: "ix_trips_departure_city_id",
                table: "trips",
                column: "departure_city_id");

            migrationBuilder.AddForeignKey(
                name: "fk_trips_cities_arrival_city_id",
                table: "trips",
                column: "arrival_city_id",
                principalTable: "cities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_trips_cities_departure_city_id",
                table: "trips",
                column: "departure_city_id",
                principalTable: "cities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_trips_cities_arrival_city_id",
                table: "trips");

            migrationBuilder.DropForeignKey(
                name: "fk_trips_cities_departure_city_id",
                table: "trips");

            migrationBuilder.DropIndex(
                name: "ix_trips_arrival_city_id",
                table: "trips");

            migrationBuilder.DropIndex(
                name: "ix_trips_departure_city_id",
                table: "trips");

            migrationBuilder.DropColumn(
                name: "arrival_city_id",
                table: "trips");

            migrationBuilder.DropColumn(
                name: "departure_city_id",
                table: "trips");
        }
    }
}
