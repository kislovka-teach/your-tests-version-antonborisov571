using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PassingTrips.Migrations
{
    /// <inheritdoc />
    public partial class AddedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "date_registration", "driving_experience", "first_name", "last_name", "login", "number_phone", "password" },
                values: new object[] { 1, new DateOnly(1, 1, 1), 1, "Вася", "Пупкин", "login123", "1234567890", "qwerty1!Q" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 1);
        }
    }
}
