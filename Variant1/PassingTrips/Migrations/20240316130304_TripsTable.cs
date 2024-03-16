using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PassingTrips.Migrations
{
    /// <inheritdoc />
    public partial class TripsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "trips",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    driver_id = table.Column<int>(type: "integer", nullable: false),
                    driver_id1 = table.Column<long>(type: "bigint", nullable: false),
                    departure_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    arrival_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    price = table.Column<int>(type: "integer", nullable: false),
                    max_count_passenger = table.Column<int>(type: "integer", nullable: false),
                    car = table.Column<string>(type: "text", nullable: false),
                    is_music = table.Column<bool>(type: "boolean", nullable: false),
                    is_smoking = table.Column<bool>(type: "boolean", nullable: false),
                    is_animal = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trips", x => x.id);
                    table.ForeignKey(
                        name: "fk_trips_users_driver_id1",
                        column: x => x.driver_id1,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trip_user",
                columns: table => new
                {
                    passenger_trips_id = table.Column<int>(type: "integer", nullable: false),
                    passengers_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trip_user", x => new { x.passenger_trips_id, x.passengers_id });
                    table.ForeignKey(
                        name: "fk_trip_user_trips_passenger_trips_id",
                        column: x => x.passenger_trips_id,
                        principalTable: "trips",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_trip_user_users_passengers_id",
                        column: x => x.passengers_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_trip_user_passengers_id",
                table: "trip_user",
                column: "passengers_id");

            migrationBuilder.CreateIndex(
                name: "ix_trips_driver_id1",
                table: "trips",
                column: "driver_id1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trip_user");

            migrationBuilder.DropTable(
                name: "trips");
        }
    }
}
