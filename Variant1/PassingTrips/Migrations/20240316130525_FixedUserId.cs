using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PassingTrips.Migrations
{
    /// <inheritdoc />
    public partial class FixedUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_reviews_users_recipient_id1",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "fk_reviews_users_sender_id1",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "fk_trips_users_driver_id1",
                table: "trips");

            migrationBuilder.DropIndex(
                name: "ix_trips_driver_id1",
                table: "trips");

            migrationBuilder.DropIndex(
                name: "ix_reviews_recipient_id1",
                table: "reviews");

            migrationBuilder.DropIndex(
                name: "ix_reviews_sender_id1",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "driver_id1",
                table: "trips");

            migrationBuilder.DropColumn(
                name: "recipient_id1",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "sender_id1",
                table: "reviews");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "passengers_id",
                table: "trip_user",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "ix_trips_driver_id",
                table: "trips",
                column: "driver_id");

            migrationBuilder.CreateIndex(
                name: "ix_reviews_recipient_id",
                table: "reviews",
                column: "recipient_id");

            migrationBuilder.CreateIndex(
                name: "ix_reviews_sender_id",
                table: "reviews",
                column: "sender_id");

            migrationBuilder.AddForeignKey(
                name: "fk_reviews_users_recipient_id",
                table: "reviews",
                column: "recipient_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_reviews_users_sender_id",
                table: "reviews",
                column: "sender_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_trips_users_driver_id",
                table: "trips",
                column: "driver_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_reviews_users_recipient_id",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "fk_reviews_users_sender_id",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "fk_trips_users_driver_id",
                table: "trips");

            migrationBuilder.DropIndex(
                name: "ix_trips_driver_id",
                table: "trips");

            migrationBuilder.DropIndex(
                name: "ix_reviews_recipient_id",
                table: "reviews");

            migrationBuilder.DropIndex(
                name: "ix_reviews_sender_id",
                table: "reviews");

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "users",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "driver_id1",
                table: "trips",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "passengers_id",
                table: "trip_user",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<long>(
                name: "recipient_id1",
                table: "reviews",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "sender_id1",
                table: "reviews",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "ix_trips_driver_id1",
                table: "trips",
                column: "driver_id1");

            migrationBuilder.CreateIndex(
                name: "ix_reviews_recipient_id1",
                table: "reviews",
                column: "recipient_id1");

            migrationBuilder.CreateIndex(
                name: "ix_reviews_sender_id1",
                table: "reviews",
                column: "sender_id1");

            migrationBuilder.AddForeignKey(
                name: "fk_reviews_users_recipient_id1",
                table: "reviews",
                column: "recipient_id1",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_reviews_users_sender_id1",
                table: "reviews",
                column: "sender_id1",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_trips_users_driver_id1",
                table: "trips",
                column: "driver_id1",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
