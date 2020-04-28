using Microsoft.EntityFrameworkCore.Migrations;

namespace DineWithMe.Migrations
{
    public partial class addedImagesToRestaurantsDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrl", "Location" },
                values: new object[] { "https://res.cloudinary.com/dzffwrzqb/image/upload/v1588051715/Ceviche_i5ai5k.jpg", "St.Petersburg, Fl" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageUrl", "Location" },
                values: new object[] { "https://res.cloudinary.com/dzffwrzqb/image/upload/v1588051736/RedMesa_qdqyml.jpg", "St.Petersburg, Fl" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImageUrl", "Location" },
                values: new object[] { "https://res.cloudinary.com/dzffwrzqb/image/upload/v1588051732/ParkshoreGrill_hfcqp7.jpg", "St.Petersburg, Fl" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImageUrl", "Location" },
                values: new object[] { "https://res.cloudinary.com/dzffwrzqb/image/upload/v1588051720/Harveys4thStreetGrill_shx5pc.jpg", "St.Petersburg, Fl" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ImageUrl", "Location" },
                values: new object[] { "https://res.cloudinary.com/dzffwrzqb/image/upload/v1588051681/BellaBrava_pawxiw.jpg", "St.Petersburg, Fl" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ImageUrl", "Location" },
                values: new object[] { "https://res.cloudinary.com/dzffwrzqb/image/upload/v1588051722/HawkersAsianStreetFare_hebtp3.jpg", "St.Petersburg, Fl" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ImageUrl", "Location" },
                values: new object[] { "https://res.cloudinary.com/dzffwrzqb/image/upload/v1588051706/CasitaTaqueria_oiw2bj.jpg", "St.Petersburg, Fl" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ImageUrl", "Location" },
                values: new object[] { "https://res.cloudinary.com/dzffwrzqb/image/upload/v1588051735/RawkStarCafeStPete_uyc2bm.jpg", "St.Petersburg, Fl" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ImageUrl", "Location" },
                values: new object[] { "https://res.cloudinary.com/dzffwrzqb/image/upload/v1588051713/Central_Melt_eubwhw.jpg", "St.Petersburg, Fl" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ImageUrl", "Location" },
                values: new object[] { "https://res.cloudinary.com/dzffwrzqb/image/upload/v1588051688/BodegaonCentral_udxwnf.jpg", "St.Petersburg, Fl" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Restaurants");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: null);
        }
    }
}
