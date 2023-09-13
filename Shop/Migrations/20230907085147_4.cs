using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HowToUse",
                table: "CareCosmetics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CareCosmetics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CareCosmeticCategory",
                value: 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HowToUse",
                table: "CareCosmetics");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Brands");

            migrationBuilder.UpdateData(
                table: "CareCosmetics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CareCosmeticCategory",
                value: 0);
        }
    }
}
