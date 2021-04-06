using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolApplication.Data.Migrations
{
    public partial class ModelsUpdate11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f61d558-9be0-4875-8184-4b0bdd78adf4");

            migrationBuilder.DropColumn(
                name: "Homework",
                table: "StudentInfos");

            migrationBuilder.DropColumn(
                name: "NumberOfStudents",
                table: "StudentInfos");

            migrationBuilder.AddColumn<string>(
                name: "Homework",
                table: "Groups",
                maxLength: 50,
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "ApplicationUserType", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0ad5d719-d01b-4938-8215-63e6b2991359", 0, 0, 0, "d95282de-e6ce-43ab-bc0d-632ae470d368", "yahya.wpm@gmail.com", true, null, 0, null, false, null, "YAHYA.WPM@GMAIL.COM", "YAHYA.WPM@GMAIL.COM", "AQAAAAEAACcQAAAAED1TFh8uNjp1HNsHjNGVezZprBVJoN4wE1Vi07GOpCT2pj3zuOfSShlDT6b93kuO4Q==", null, false, "", false, "yahya.wpm@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0ad5d719-d01b-4938-8215-63e6b2991359");

            migrationBuilder.DropColumn(
                name: "Homework",
                table: "Groups");

            migrationBuilder.AddColumn<string>(
                name: "Homework",
                table: "StudentInfos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfStudents",
                table: "StudentInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "ApplicationUserType", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8f61d558-9be0-4875-8184-4b0bdd78adf4", 0, 0, 0, "b17d1e11-8a77-4e88-aae7-88cd37a3ff8c", "yahya.wpm@gmail.com", true, null, 0, null, false, null, "YAHYA.WPM@GMAIL.COM", "YAHYA.WPM@GMAIL.COM", "AQAAAAEAACcQAAAAECwVpxQ3+NbJBiMd0pA8ezVbG0iaZ86slB2DxF1bZAdWNoHF3i7T1gklI4wLUcvcgA==", null, false, "", false, "yahya.wpm@gmail.com" });
        }
    }
}
