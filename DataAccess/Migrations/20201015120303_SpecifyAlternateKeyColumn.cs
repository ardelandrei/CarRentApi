using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class SpecifyAlternateKeyColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_ManufacturerDetails_VIN",
                table: "ManufacturerDetails",
                column: "VIN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_ManufacturerDetails_VIN",
                table: "ManufacturerDetails");
        }
    }
}
