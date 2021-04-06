using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolApplication.Data.Migrations
{
    public partial class UpdateMigration11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75e29869-1c96-4a69-91eb-548e9a8972e2");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ApplicationUserType", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5992c4b9-20ef-4378-93b2-3e92dd80b9d2", 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2996b547-fc4c-4264-a307-af83f335fd23", "yahya.wpm@gmail.com", true, null, 0, null, false, null, "YAHYA.WPM@GMAIL.COM", "YAHYA.WPM@GMAIL.COM", "AQAAAAEAACcQAAAAEAM+YIQtd7z5JJAlu4QWkYZgWGJQO60KxVB3AGcyVrPDLqwAooBXoaECGjgdcfmCeg==", null, false, "", false, "yahya.wpm@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5992c4b9-20ef-4378-93b2-3e92dd80b9d2");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ApplicationUserType", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "75e29869-1c96-4a69-91eb-548e9a8972e2", 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5d754c5f-3c07-4c55-bdd5-5346ce93bd2f", "yahya.wpm@gmail.com", true, null, 0, null, false, null, "YAHYA.WPM@GMAIL.COM", "YAHYA.WPM@GMAIL.COM", "AQAAAAEAACcQAAAAEBryTTTFaot/SCXTh+S9HWdTwExDMHk5V6S9RzlCGdKohCiAywvA33ohq/iLIWyL3Q==", null, false, "", false, "yahya.wpm@gmail.com" });
        }
    }
}
