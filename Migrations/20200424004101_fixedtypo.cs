using Microsoft.EntityFrameworkCore.Migrations;

namespace DineWithMe.Migrations
{
    public partial class fixedtypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agreements_Users_UserId",
                table: "Agreements");

            migrationBuilder.DropIndex(
                name: "IX_Agreements_UserId",
                table: "Agreements");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Agreements");

            migrationBuilder.AddColumn<int>(
                name: "FriendId",
                table: "Agreements",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_FriendId",
                table: "Agreements",
                column: "FriendId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agreements_Users_FriendId",
                table: "Agreements",
                column: "FriendId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agreements_Users_FriendId",
                table: "Agreements");

            migrationBuilder.DropIndex(
                name: "IX_Agreements_FriendId",
                table: "Agreements");

            migrationBuilder.DropColumn(
                name: "FriendId",
                table: "Agreements");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Agreements",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_UserId",
                table: "Agreements",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agreements_Users_UserId",
                table: "Agreements",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
