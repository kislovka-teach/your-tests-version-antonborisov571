using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Freelance.Migrations
{
    /// <inheritdoc />
    public partial class FixedSomeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: "3");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "sender_id",
                table: "reviews",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "reference_user_id",
                table: "freelancers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "password", "role", "username" },
                values: new object[,]
                {
                    { 1, "admin123", 1, "admin" },
                    { 2, "user123", 0, "user1" },
                    { 3, "user456", 0, "user2" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_reviews_sender_id",
                table: "reviews",
                column: "sender_id");

            migrationBuilder.CreateIndex(
                name: "ix_freelancers_reference_user_id",
                table: "freelancers",
                column: "reference_user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_freelancers_users_reference_user_id",
                table: "freelancers",
                column: "reference_user_id",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_freelancers_users_reference_user_id",
                table: "freelancers");

            migrationBuilder.DropForeignKey(
                name: "fk_reviews_users_sender_id",
                table: "reviews");

            migrationBuilder.DropIndex(
                name: "ix_reviews_sender_id",
                table: "reviews");

            migrationBuilder.DropIndex(
                name: "ix_freelancers_reference_user_id",
                table: "freelancers");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "sender_id",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "reference_user_id",
                table: "freelancers");

            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "users",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "password", "role", "username" },
                values: new object[,]
                {
                    { "1", "admin123", 0, "admin" },
                    { "2", "user123", 1, "user1" },
                    { "3", "user456", 1, "user2" }
                });
        }
    }
}
