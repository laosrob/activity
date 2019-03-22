using Microsoft.EntityFrameworkCore.Migrations;

namespace exam.Migrations
{
    public partial class sec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_activities_UserId",
                table: "activities",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_activities_users_UserId",
                table: "activities",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_activities_users_UserId",
                table: "activities");

            migrationBuilder.DropIndex(
                name: "IX_activities_UserId",
                table: "activities");
        }
    }
}
