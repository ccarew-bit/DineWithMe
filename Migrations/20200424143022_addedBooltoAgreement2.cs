using Microsoft.EntityFrameworkCore.Migrations;

namespace DineWithMe.Migrations
{
    public partial class addedBooltoAgreement2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agreements_Users_FriendId",
                table: "Agreements");

            migrationBuilder.DropForeignKey(
                name: "FK_Agreements_Users_RequestorId",
                table: "Agreements");

            migrationBuilder.DropIndex(
                name: "IX_Agreements_FriendId",
                table: "Agreements");

            migrationBuilder.DropIndex(
                name: "IX_Agreements_RequestorId",
                table: "Agreements");

            migrationBuilder.DropColumn(
                name: "FriendId",
                table: "Agreements");

            migrationBuilder.DropColumn(
                name: "RequestorId",
                table: "Agreements");

            migrationBuilder.AddColumn<bool>(
                name: "Friend",
                table: "Agreements",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "Agreements",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Requestor",
                table: "Agreements",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_RequestId",
                table: "Agreements",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agreements_Requests_RequestId",
                table: "Agreements",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agreements_Requests_RequestId",
                table: "Agreements");

            migrationBuilder.DropIndex(
                name: "IX_Agreements_RequestId",
                table: "Agreements");

            migrationBuilder.DropColumn(
                name: "Friend",
                table: "Agreements");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Agreements");

            migrationBuilder.DropColumn(
                name: "Requestor",
                table: "Agreements");

            migrationBuilder.AddColumn<int>(
                name: "FriendId",
                table: "Agreements",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequestorId",
                table: "Agreements",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_FriendId",
                table: "Agreements",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_RequestorId",
                table: "Agreements",
                column: "RequestorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agreements_Users_FriendId",
                table: "Agreements",
                column: "FriendId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agreements_Users_RequestorId",
                table: "Agreements",
                column: "RequestorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
