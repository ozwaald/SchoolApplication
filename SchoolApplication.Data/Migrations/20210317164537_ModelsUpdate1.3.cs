using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolApplication.Data.Migrations
{
    public partial class ModelsUpdate13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5992c4b9-20ef-4378-93b2-3e92dd80b9d2");

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ApplicationUserType", "BirthDate", "Comments", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f9aee0ab-02ab-4e3f-a5c2-a268dc636d3f", 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "bb4df6a2-390c-4c7e-ac1e-02a8fc8ab7b0", "yahya.wpm@gmail.com", true, null, 0, null, false, null, "YAHYA.WPM@GMAIL.COM", "YAHYA.WPM@GMAIL.COM", "AQAAAAEAACcQAAAAEM7d992rLj8VNGiGlac3TqSdEnpLZw4CoXdMvual/BTyEyeDOP8jaA54SZvxxbFTgQ==", null, false, "", false, "yahya.wpm@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f9aee0ab-02ab-4e3f-a5c2-a268dc636d3f");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ApplicationUserType", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5992c4b9-20ef-4378-93b2-3e92dd80b9d2", 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2996b547-fc4c-4264-a307-af83f335fd23", "yahya.wpm@gmail.com", true, null, 0, null, false, null, "YAHYA.WPM@GMAIL.COM", "YAHYA.WPM@GMAIL.COM", "AQAAAAEAACcQAAAAEAM+YIQtd7z5JJAlu4QWkYZgWGJQO60KxVB3AGcyVrPDLqwAooBXoaECGjgdcfmCeg==", null, false, "", false, "yahya.wpm@gmail.com" });
        }
    }
}
