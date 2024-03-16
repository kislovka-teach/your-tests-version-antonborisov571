using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PassingTrips.Migrations
{
    /// <inheritdoc />
    public partial class FixedCoordinateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Coordinates_CoordinateId1",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CoordinateId1",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CoordinateId1",
                table: "Cities");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Coordinates",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CoordinateId",
                table: "Cities",
                column: "CoordinateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Coordinates_CoordinateId",
                table: "Cities",
                column: "CoordinateId",
                principalTable: "Coordinates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Coordinates_CoordinateId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CoordinateId",
                table: "Cities");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Coordinates",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "CoordinateId1",
                table: "Cities",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CoordinateId1",
                table: "Cities",
                column: "CoordinateId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Coordinates_CoordinateId1",
                table: "Cities",
                column: "CoordinateId1",
                principalTable: "Coordinates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
