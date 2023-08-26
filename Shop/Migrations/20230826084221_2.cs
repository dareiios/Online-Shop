using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_CareCosmetics_CareCosmeticId",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Brands_CareCosmeticId",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "CareCosmeticId",
                table: "Brands");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "CareCosmetics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CareCosmetics_BrandId",
                table: "CareCosmetics",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_CareCosmetics_Brands_BrandId",
                table: "CareCosmetics",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CareCosmetics_Brands_BrandId",
                table: "CareCosmetics");

            migrationBuilder.DropIndex(
                name: "IX_CareCosmetics_BrandId",
                table: "CareCosmetics");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "CareCosmetics");

            migrationBuilder.AddColumn<int>(
                name: "CareCosmeticId",
                table: "Brands",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brands_CareCosmeticId",
                table: "Brands",
                column: "CareCosmeticId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_CareCosmetics_CareCosmeticId",
                table: "Brands",
                column: "CareCosmeticId",
                principalTable: "CareCosmetics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
