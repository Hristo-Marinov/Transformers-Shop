using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransformersShop.Migrations
{
    public partial class RatingsToProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "83268ed9-53aa-492a-9fe0-5dcec60f8868");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bd5fedf4-e54c-4643-969c-c4c1279ff1f1", "AQAAAAEAACcQAAAAEKXx/zxDssTF7zYBuv4NHTlQ0/08/wUhMmipO/F4+O1T6SdGraTUu5qIaCTZy8aukQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "6804db9c-7452-470f-8c87-1b40d2bc48a1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "98c72cb0-ced0-4259-9210-0e0cc52efbee", "AQAAAAEAACcQAAAAENtEG3YFtRZzu4zsXvrNhzpVgiZnqU/5EqmZsBv3VBEgbPcKobw9X5XHEw2RaWTJdg==" });
        }
    }
}
