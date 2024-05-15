using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransformersShop.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "ea4416cb-abc0-4d19-b4bd-68028e82a15e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "833bf7e8-a314-4c2b-a0af-3c5d275b67c1", "AQAAAAEAACcQAAAAEEm5Z6JYMlnla28V+ufSkjJExf3jV9r4uucEAUDJgCmzD93Pyda/Y0nRpbk4RLFMdw==" });
        }
    }
}
