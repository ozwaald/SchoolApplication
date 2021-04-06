using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolApplication.Data.Migrations
{
    public partial class StudentApplicationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0337239-9601-473f-8c58-347d7bcaacdf");

            migrationBuilder.AddColumn<int>(
                name: "StudentApplicationId",
                table: "StudentApplications",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "ApplicationUserType", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e0337239-9601-473f-8c58-347d7bcaacdf", 0, 0, 0, "375f0d6f-5b35-42b5-bdb1-88226b532f41", "yahya.wpm@gmail.com", true, null, 0, null, false, null, "YAHYA.WPM@GMAIL.COM", "YAHYA.WPM@GMAIL.COM", "AQAAAAEAACcQAAAAELcK9OYGGocVfD7TKLEf7JqzbQmq7IBWMa9r8Rpm0FI0e2mMbQP9GEV3C+sGuYp4YA==", null, false, "", false, "yahya.wpm@gmail.com" });
        }
    }
}
