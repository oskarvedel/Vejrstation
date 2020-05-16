using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vejrstation.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherObservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    TemperatureCelsius = table.Column<double>(type: "float", nullable: false),
                    Humidity_Percentage = table.Column<int>(type: "int", nullable: false),
                    Pressure_Millibar = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherObservations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "PasswordHash", "UserName" },
                values: new object[,]
                {
                    { 1001, "asdfasdf12341234", "Flydende vejrstation 999" },
                    { 1002, "$2b$10$CVhr0CGf2jgOGzAGBW1QkuGoyD9zHEFfuMJ9PcgKVdfHmEozy.7g6", "John_1954" },
                    { 1003, "$2b$10$qlb0TxXk9jPbWwTMBS1lYOWdl34xwtxPEQ9NDYtyKjH0EqQzTJSB.", "Jesper Theilgaard" },
                    { 1004, "$2b$10$CnmGJqhTvRb3plF.KemOPudF29hlXi2kwcnZ37Ao1nK0vChBM94CG", "Peter Qvortrup Geisling" },
                    { 1005, "$2b$10$hI.1VnFnpO.TMQwfjerBBeh3VER0QbphRGKVAGtU9Bril7PE5AYbm", "Dr. Pjuskibusk" }
                });

            migrationBuilder.InsertData(
                table: "WeatherObservations",
                columns: new[] { "Id", "Date", "Humidity_Percentage", "Latitude", "Longitude", "Name", "Pressure_Millibar", "TemperatureCelsius" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 101010101.0, 2222222.0, "Kolding", 3.0, 1.0 },
                    { 1002, new DateTime(2020, 5, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), 10, 23.45224, 19.353000000000002, "Bunden af bubbers badekar", 9.1999999999999993, 33.100000000000001 },
                    { 1003, new DateTime(2020, 2, 3, 1, 50, 0, 0, DateTimeKind.Unspecified), 10, 12.46733, 2.2351999999999999, "Himmelbjerget", 9.1999999999999993, 33.100000000000001 },
                    { 1004, new DateTime(2020, 11, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), 10, 56.158149999999999, 10.21203, "Hjemme paa gaarden", 9.1999999999999993, 33.100000000000001 },
                    { 1005, new DateTime(2020, 11, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), 100, 69.420000000000002, 69.420000000000002, "Atlantis", 9000.2000000000007, 20.100000000000001 },
                    { 1006, new DateTime(2020, 11, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), 50, 12.432399999999999, 54.123399999999997, "Anna Lises Bar", 900.0, 25.100000000000001 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "WeatherObservations");
        }
    }
}
