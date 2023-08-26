using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "CareCosmetics");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "CareCosmetics",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
