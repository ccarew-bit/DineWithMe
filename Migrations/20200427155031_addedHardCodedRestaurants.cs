using Microsoft.EntityFrameworkCore.Migrations;

namespace DineWithMe.Migrations
{
    public partial class addedHardCodedRestaurants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Expenses", "Hours", "Name", "Reviews", "Type" },
                values: new object[,]
                {
                    { 6, "$$", "9am-5pm", "Hawkers Asian Street Fare", "GREAT", "Asian" },
                    { 7, "$", "9am-5pm", "Casita Taqueria", "GREAT", "Mexican" },
                    { 8, "$", "9am-5pm", "Rawk Star Cafe St. Pete", "GREAT", "Vegan" },
                    { 9, "$", "9am-5pm", "Central Melt", "GREAT", "Deli" },
                    { 10, "$", "9am-5pm", "Bodega on Central", "GREAT", "Cuban" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
