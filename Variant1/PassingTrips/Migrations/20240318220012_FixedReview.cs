using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PassingTrips.Migrations
{
    /// <inheritdoc />
    public partial class FixedReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_reviews_users_recipient_id",
                table: "reviews");

            migrationBuilder.RenameColumn(
                name: "recipient_id",
                table: "reviews",
                newName: "trip_id");

            migrationBuilder.RenameIndex(
                name: "ix_reviews_recipient_id",
                table: "reviews",
                newName: "ix_reviews_trip_id");

            migrationBuilder.AddForeignKey(
                name: "fk_reviews_trips_trip_id",
                table: "reviews",
                column: "trip_id",
                principalTable: "trips",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_reviews_trips_trip_id",
                table: "reviews");

            migrationBuilder.RenameColumn(
                name: "trip_id",
                table: "reviews",
                newName: "recipient_id");

            migrationBuilder.RenameIndex(
                name: "ix_reviews_trip_id",
                table: "reviews",
                newName: "ix_reviews_recipient_id");

            migrationBuilder.AddForeignKey(
                name: "fk_reviews_users_recipient_id",
                table: "reviews",
                column: "recipient_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
