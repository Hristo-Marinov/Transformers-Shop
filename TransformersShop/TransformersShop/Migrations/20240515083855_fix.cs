using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransformersShop.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: 1,
                column: "Picture",
                value: "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/9ece39f6-6737-42b8-b282-f99688062708/d6e4o93-ff76b235-071a-47e8-b3d0-9b02147fbd0c.jpg/v1/fill/w_525,h_350,q_70,strp/tf_fanart___autobots_vacation_ver2_by_goddessmechanic_d6e4o93-350t.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7ImhlaWdodCI6Ijw9NTMzIiwicGF0aCI6IlwvZlwvOWVjZTM5ZjYtNjczNy00MmI4LWIyODItZjk5Njg4MDYyNzA4XC9kNmU0bzkzLWZmNzZiMjM1LTA3MWEtNDdlOC1iM2QwLTliMDIxNDdmYmQwYy5qcGciLCJ3aWR0aCI6Ijw9ODAwIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmltYWdlLm9wZXJhdGlvbnMiXX0.vdyCpLE2-clAoreexFRcOwy12j2HnSDxKoenEOZltSQ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Picture",
                value: "C:\\Users\\Ico\\Documents\\GitHub\\Transformers-Shop\\TransformersShop\\TransformersShop\\Entity\\ProductPictures\\6b9683865dbd76069c6189d1dc7c2f5b.jpg");
        }
    }
}
