using Microsoft.EntityFrameworkCore.Migrations;

namespace Vejrstation.Migrations
{
    public partial class accountseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "PasswordHash", "UserName" },
                values: new object[,]
                {
                    { 1, "asdfasdf12341234", "Flydende vejrstation 999" },
                    { 2, "$2b$10$xeAXtAm.AhD5nKh4EVnTmuOTej01dSpqt58ELiYk5pphIBEvQve.u", "John_1954" },
                    { 3, "$2b$10$rqFX4RElsidIPg3Ib0rr4ejKpmzni84yAW9PehXNZA4xPuUZxjqYe", "Jesper Theilgaard" },
                    { 4, "$2b$10$Toun7XQsR.mdemKPuoME2u640UAaanuyxfaAFMrRWJT4M25C/JN6e", "Peter Qvortrup Geisling" },
                    { 5, "$2b$10$0nMAqaxLiuPrBkpZg0m/fuu/Wm7qLSklcmv08AfjVMWf2ihb0EGby", "Dr. Pjuskibusk" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
