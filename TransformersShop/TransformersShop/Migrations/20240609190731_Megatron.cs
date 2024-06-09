using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransformersShop.Migrations
{
    public partial class Megatron : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "a00c801d-a30a-4058-a040-0ae1add409f8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e23e2b34-4c54-467f-9df8-e232449d19d6", "AQAAAAEAACcQAAAAEHxCHLMBMw9Sj7mCzeI3WZJa4517bblY8EvjIg4yUatkkAQFmzXXy4O7BRf1Ik+LJA==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Picture",
                value: "https://wallpapercave.com/wp/wp3466402.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "5c798e15-0405-4089-af5d-c4888ab16796");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "acab9182-1db7-494d-99ab-8653d8d547b1", "AQAAAAEAACcQAAAAEAPNNmEjkbiVg02oVUUdal8ur/3lLoaglnhx+khWrkqDQHbyfrZO/A+Yjq41QHzdOA==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Picture",
                value: "https://i.pinimg.com/736x/3e/87/a1/3e87a13aedb09fcaac9ce75b5ad93d27.jpg");
        }
    }
}
