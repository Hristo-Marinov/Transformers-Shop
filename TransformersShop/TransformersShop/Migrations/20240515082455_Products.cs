using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransformersShop.Migrations
{
    public partial class Products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "794d77e9-2d25-4899-bae1-062060ddf47b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "78496352-05db-4ee5-96e5-73038f10dc44", "AQAAAAEAACcQAAAAEHaWoXGuFhtsvaSc9AQ1eO27v7O+mHzZHlMPwgFdBrjJQmFJZZ8kzAVsn2MlbQOgEg==" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Picture" },
                values: new object[,]
                {
                    { 1, "Description for Transformer 1", "Transformer 1", "C:\\Users\\Ico\\Documents\\GitHub\\Transformers-Shop\\TransformersShop\\TransformersShop\\Entity\\ProductPictures\\6b9683865dbd76069c6189d1dc7c2f5b.jpg" },
                    { 2, "Description for Transformer 2", "Transformer 2", "C:\\Users\\Ico\\Documents\\GitHub\\Transformers-Shop\\TransformersShop\\TransformersShop\\Entity\\ProductPictures\\627de011e2153346c42f9b8189329821.jpg" },
                    { 3, "Description for Transformer 3", "Transformer 3", "C:\\Users\\Ico\\Documents\\GitHub\\Transformers-Shop\\TransformersShop\\TransformersShop\\Entity\\ProductPictures\\download (1).jpg" },
                    { 4, "Description for Transformer 4", "Transformer 4", "C:\\Users\\Ico\\Documents\\GitHub\\Transformers-Shop\\TransformersShop\\TransformersShop\\Entity\\ProductPictures\\maxresdefault.jpg" }
                });

            migrationBuilder.InsertData(
                table: "ProductsInStock",
                columns: new[] { "ProductId", "Count" },
                values: new object[,]
                {
                    { 1, 10 },
                    { 2, 10 },
                    { 3, 10 },
                    { 4, 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductsInStock",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductsInStock",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductsInStock",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductsInStock",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "039bfcea-917f-498a-a146-36fb7e1d126c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "958727d3-0f9e-42af-a2cc-758d46a9e90e", "AQAAAAEAACcQAAAAEHVkFIeXrdNVl5prRlu6nTzmAKhBC7fHyR8TlFwyDDUwm2jNRFiM+CF8DhgvJm6VrA==" });
        }
    }
}
