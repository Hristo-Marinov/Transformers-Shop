using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransformersShop.Migrations
{
    public partial class @fixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: 2,
                column: "Picture",
                value: "https://media.tenor.com/r06Prd4E5i0AAAAe/transformers-funny.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Picture",
                value: "https://i.pinimg.com/736x/3e/87/a1/3e87a13aedb09fcaac9ce75b5ad93d27.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Picture",
                value: "https://i.pinimg.com/736x/3e/87/a1/3e87a13aedb09fcaac9ce75b5ad93d27.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "46b76f0e-e0c5-46a1-8690-257a13956ead");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5a245625-258b-4998-b968-e50cbd00412e", "AQAAAAEAACcQAAAAEEEOaGKUxekvDRV1mgd2BMEj9CMELWj6fYBmpRPbdZ7S0OvY9UYW/6deaIri37Kopg==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Picture",
                value: "C:\\Users\\Ico\\Documents\\GitHub\\Transformers-Shop\\TransformersShop\\TransformersShop\\Entity\\ProductPictures\\627de011e2153346c42f9b8189329821.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Picture",
                value: "C:\\Users\\Ico\\Documents\\GitHub\\Transformers-Shop\\TransformersShop\\TransformersShop\\Entity\\ProductPictures\\download (1).jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Picture",
                value: "C:\\Users\\Ico\\Documents\\GitHub\\Transformers-Shop\\TransformersShop\\TransformersShop\\Entity\\ProductPictures\\maxresdefault.jpg");
        }
    }
}
