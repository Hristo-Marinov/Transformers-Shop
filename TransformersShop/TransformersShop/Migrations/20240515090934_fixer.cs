using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransformersShop.Migrations
{
    public partial class fixer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "cd05249f-421f-4814-bc64-56029019df8a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "23f97d48-cdb4-42d7-8b0a-ec2699fbad3f", "AQAAAAEAACcQAAAAEIzcJPTnS5etTY4l0rTWZ1HrqQHxkqkWVDsH2D/rg/7YEqKDuzRyA9Q0Rjg1XZm1ew==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Picture",
                value: "https://i.pinimg.com/originals/9f/bf/05/9fbf05e55cabc5e5ba61e5df243561d5.gif");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "0930d8a8-9d7a-407d-a83e-76193d2024a0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "75a4a177-63a0-4e0b-a6c8-8ce14e26451e", "AQAAAAEAACcQAAAAEECfh+a1KMDmiPF56FzeMfWr1yaSRok4lfvATs2pJvQ3qRH4Jj0SEp0C4iX4wPZViQ==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Picture",
                value: "https://i.pinimg.com/736x/3e/87/a1/3e87a13aedb09fcaac9ce75b5ad93d27.jpg");
        }
    }
}
