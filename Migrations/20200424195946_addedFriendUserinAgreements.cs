using Microsoft.EntityFrameworkCore.Migrations;

namespace DineWithMe.Migrations
{
    public partial class addedFriendUserinAgreements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Friend",
                table: "Agreements");

            migrationBuilder.DropColumn(
                name: "Requestor",
                table: "Agreements");

            migrationBuilder.AddColumn<bool>(
                name: "FriendApproved",
                table: "Agreements",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "FriendId",
                table: "Agreements",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequestorApproved",
                table: "Agreements",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RequestorId",
                table: "Agreements",
                nullable: true);

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
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agreements_Users_RequestorId",
                table: "Agreements",
                column: "RequestorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FriendApproved",
                table: "Agreements");

            migrationBuilder.DropColumn(
                name: "FriendId",
                table: "Agreements");

            migrationBuilder.DropColumn(
                name: "RequestorApproved",
                table: "Agreements");

            migrationBuilder.DropColumn(
                name: "RequestorId",
                table: "Agreements");

            migrationBuilder.AddColumn<bool>(
                name: "Friend",
                table: "Agreements",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Requestor",
                table: "Agreements",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
