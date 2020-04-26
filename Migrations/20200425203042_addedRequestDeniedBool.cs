using Microsoft.EntityFrameworkCore.Migrations;

namespace DineWithMe.Migrations
{
    public partial class addedRequestDeniedBool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRequestDenied",
                table: "Requests",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRequestDenied",
                table: "Requests");
        }
    }
}
