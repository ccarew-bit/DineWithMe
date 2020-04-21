using Microsoft.EntityFrameworkCore.Migrations;

namespace DineWithMe.Migrations
{
    public partial class AddedForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Requests_FriendId",
                table: "Requests",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestorId",
                table: "Requests",
                column: "RequestorId");

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_RequestorId",
                table: "Agreements",
                column: "RequestorId");

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_RestaurantId",
                table: "Agreements",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_UserId",
                table: "Agreements",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agreements_Users_RequestorId",
                table: "Agreements",
                column: "RequestorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agreements_Restaurants_RestaurantId",
                table: "Agreements",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agreements_Users_UserId",
                table: "Agreements",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_FriendId",
                table: "Requests",
                column: "FriendId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_RequestorId",
                table: "Requests",
                column: "RequestorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agreements_Users_RequestorId",
                table: "Agreements");

            migrationBuilder.DropForeignKey(
                name: "FK_Agreements_Restaurants_RestaurantId",
                table: "Agreements");

            migrationBuilder.DropForeignKey(
                name: "FK_Agreements_Users_UserId",
                table: "Agreements");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_FriendId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_RequestorId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_FriendId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RequestorId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Agreements_RequestorId",
                table: "Agreements");

            migrationBuilder.DropIndex(
                name: "IX_Agreements_RestaurantId",
                table: "Agreements");

            migrationBuilder.DropIndex(
                name: "IX_Agreements_UserId",
                table: "Agreements");
        }
    }
}
