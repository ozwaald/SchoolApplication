using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolApplication.Data.Migrations
{
    public partial class ModelsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55b2a43c-5a2f-4817-aff7-db2b0a2c0222");

            migrationBuilder.DropColumn(
                name: "StudentApplications",
                table: "StudentApplications");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfTeachers",
                table: "TeacherInfos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfTeacherApplications",
                table: "TeacherApplications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfStudents",
                table: "StudentInfos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfStudentApplications",
                table: "StudentApplications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "ApplicationUserType", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8f61d558-9be0-4875-8184-4b0bdd78adf4", 0, 0, 0, "b17d1e11-8a77-4e88-aae7-88cd37a3ff8c", "yahya.wpm@gmail.com", true, null, 0, null, false, null, "YAHYA.WPM@GMAIL.COM", "YAHYA.WPM@GMAIL.COM", "AQAAAAEAACcQAAAAECwVpxQ3+NbJBiMd0pA8ezVbG0iaZ86slB2DxF1bZAdWNoHF3i7T1gklI4wLUcvcgA==", null, false, "", false, "yahya.wpm@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f61d558-9be0-4875-8184-4b0bdd78adf4");

            migrationBuilder.DropColumn(
                name: "NumberOfTeachers",
                table: "TeacherInfos");

            migrationBuilder.DropColumn(
                name: "NumberOfTeacherApplications",
                table: "TeacherApplications");

            migrationBuilder.DropColumn(
                name: "NumberOfStudents",
                table: "StudentInfos");

            migrationBuilder.DropColumn(
                name: "NumberOfStudentApplications",
                table: "StudentApplications");

            migrationBuilder.AddColumn<int>(
                name: "StudentApplications",
                table: "StudentApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "ApplicationUserType", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "55b2a43c-5a2f-4817-aff7-db2b0a2c0222", 0, 0, 0, "78d9609f-cb1e-4120-a657-a5c6f59a5622", "yahya.wpm@gmail.com", true, null, 0, null, false, null, "YAHYA.WPM@GMAIL.COM", "YAHYA.WPM@GMAIL.COM", "AQAAAAEAACcQAAAAEGmRqliLmPuYq7VgKIsmY96Pf3kNmLSrxz/Cv5c5IW7WoBlASh22/jYY0YkAIGYYnQ==", null, false, "", false, "yahya.wpm@gmail.com" });
        }
    }
}
