using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PassingTrips.Migrations
{
    /// <inheritdoc />
    public partial class FixedNaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Coordinates_CoordinateId",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coordinates",
                table: "Coordinates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Coordinates",
                newName: "coordinates");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "cities");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "users",
                newName: "login");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "NumberPhone",
                table: "users",
                newName: "number_phone");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "users",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "users",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "DrivingExperience",
                table: "users",
                newName: "driving_experience");

            migrationBuilder.RenameColumn(
                name: "DateRegistration",
                table: "users",
                newName: "date_registration");

            migrationBuilder.RenameColumn(
                name: "Width",
                table: "coordinates",
                newName: "width");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "coordinates",
                newName: "longitude");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "coordinates",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "cities",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "cities",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "CoordinateId",
                table: "cities",
                newName: "coordinate_id");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_CoordinateId",
                table: "cities",
                newName: "ix_cities_coordinate_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_coordinates",
                table: "coordinates",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_cities",
                table: "cities",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_cities_coordinates_coordinate_id",
                table: "cities",
                column: "coordinate_id",
                principalTable: "coordinates",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cities_coordinates_coordinate_id",
                table: "cities");

            migrationBuilder.DropPrimaryKey(
                name: "pk_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "pk_coordinates",
                table: "coordinates");

            migrationBuilder.DropPrimaryKey(
                name: "pk_cities",
                table: "cities");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "coordinates",
                newName: "Coordinates");

            migrationBuilder.RenameTable(
                name: "cities",
                newName: "Cities");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "login",
                table: "Users",
                newName: "Login");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "number_phone",
                table: "Users",
                newName: "NumberPhone");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "driving_experience",
                table: "Users",
                newName: "DrivingExperience");

            migrationBuilder.RenameColumn(
                name: "date_registration",
                table: "Users",
                newName: "DateRegistration");

            migrationBuilder.RenameColumn(
                name: "width",
                table: "Coordinates",
                newName: "Width");

            migrationBuilder.RenameColumn(
                name: "longitude",
                table: "Coordinates",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Coordinates",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Cities",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Cities",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "coordinate_id",
                table: "Cities",
                newName: "CoordinateId");

            migrationBuilder.RenameIndex(
                name: "ix_cities_coordinate_id",
                table: "Cities",
                newName: "IX_Cities_CoordinateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coordinates",
                table: "Coordinates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Coordinates_CoordinateId",
                table: "Cities",
                column: "CoordinateId",
                principalTable: "Coordinates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
