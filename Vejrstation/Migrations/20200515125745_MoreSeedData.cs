using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vejrstation.Migrations
{
    public partial class MoreSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WeatherObservations",
                columns: new[] { "Id", "Date", "Humidity_Percentage", "Latitude", "Longitude", "Name", "Pressure_Millibar", "TemperatureCelsius" },
                values: new object[] { 2, new DateTime(2020, 5, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), 10, 23.45224, 19.353000000000002, "Bunden af bubbers badekar", 9.1999999999999993, 33.100000000000001 });

            migrationBuilder.InsertData(
                table: "WeatherObservations",
                columns: new[] { "Id", "Date", "Humidity_Percentage", "Latitude", "Longitude", "Name", "Pressure_Millibar", "TemperatureCelsius" },
                values: new object[] { 3, new DateTime(2020, 2, 3, 1, 50, 0, 0, DateTimeKind.Unspecified), 10, 12.46733, 2.2351999999999999, "Himmelbjerget", 9.1999999999999993, 33.100000000000001 });

            migrationBuilder.InsertData(
                table: "WeatherObservations",
                columns: new[] { "Id", "Date", "Humidity_Percentage", "Latitude", "Longitude", "Name", "Pressure_Millibar", "TemperatureCelsius" },
                values: new object[] { 4, new DateTime(2020, 11, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), 10, 56.158149999999999, 10.21203, "Hjemme paa gaarden", 9.1999999999999993, 33.100000000000001 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherObservations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WeatherObservations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WeatherObservations",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
