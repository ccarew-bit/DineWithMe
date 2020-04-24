using Microsoft.EntityFrameworkCore.Migrations;

namespace DineWithMe.Migrations
{
    public partial class addedOneHardcoded4Restaurants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Type" },
                values: new object[] { "Red Mesa", "Mexican" });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Expenses", "Hours", "Name", "Reviews", "Type" },
                values: new object[,]
                {
                    { 3, "$$", "9am-5pm", "Parkshore Grill", "GREAT", "American" },
                    { 4, "$$", "9am-5pm", "Harvey's 4th Street Grill", "GREAT", "Spanish" },
                    { 5, "$$", "9am-5pm", "BellaBrava", "GREAT", "Pizza" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Type" },
                values: new object[] { "Ceviche 2 tapas St.Pete", "Spanish" });
        }
    }
}
