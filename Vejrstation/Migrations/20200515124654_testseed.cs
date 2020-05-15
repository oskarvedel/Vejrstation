using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vejrstation.Migrations
{
    public partial class testseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WeatherObservations",
                columns: new[] { "Id", "Date", "Humidity_Percentage", "Latitude", "Longitude", "Name", "Pressure_Millibar", "TemperatureCelsius" },
                values: new object[] { 1, new DateTime(2020, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 101010101.0, 2222222.0, "Kolding", 3.0, 1.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherObservations",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
