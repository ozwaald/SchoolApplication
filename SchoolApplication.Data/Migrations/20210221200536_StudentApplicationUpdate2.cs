using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolApplication.Data.Migrations
{
    public partial class StudentApplicationUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentApplications_StudentApplications_StudentApplicationId",
                table: "StudentApplications");

            migrationBuilder.DropIndex(
                name: "IX_StudentApplications_StudentApplicationId",
                table: "StudentApplications");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bf6c949b-5664-477b-8115-f030dd28ac14");

            migrationBuilder.DropColumn(
                name: "StudentApplicationId",
                table: "StudentApplications");

            migrationBuilder.AddColumn<int>(
                name: "StudentApplications",
                table: "StudentApplications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "ApplicationUserType", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "55b2a43c-5a2f-4817-aff7-db2b0a2c0222", 0, 0, 0, "78d9609f-cb1e-4120-a657-a5c6f59a5622", "yahya.wpm@gmail.com", true, null, 0, null, false, null, "YAHYA.WPM@GMAIL.COM", "YAHYA.WPM@GMAIL.COM", "AQAAAAEAACcQAAAAEGmRqliLmPuYq7VgKIsmY96Pf3kNmLSrxz/Cv5c5IW7WoBlASh22/jYY0YkAIGYYnQ==", null, false, "", false, "yahya.wpm@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55b2a43c-5a2f-4817-aff7-db2b0a2c0222");

            migrationBuilder.DropColumn(
                name: "StudentApplications",
                table: "StudentApplications");

            migrationBuilder.AddColumn<int>(
                name: "StudentApplicationId",
                table: "StudentApplications",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "ApplicationUserType", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bf6c949b-5664-477b-8115-f030dd28ac14", 0, 0, 0, "429092fc-0ae2-4770-8f3e-b60e0004d63a", "yahya.wpm@gmail.com", true, null, 0, null, false, null, "YAHYA.WPM@GMAIL.COM", "YAHYA.WPM@GMAIL.COM", "AQAAAAEAACcQAAAAENsJxwZp+x6KFzsvLou/XNvXVcWL4vfWPV4bLLgQ7FnwBSOaTpPJ+edvptxGgJA9Dw==", null, false, "", false, "yahya.wpm@gmail.com" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentApplications_StudentApplicationId",
                table: "StudentApplications",
                column: "StudentApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentApplications_StudentApplications_StudentApplicationId",
                table: "StudentApplications",
                column: "StudentApplicationId",
                principalTable: "StudentApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
