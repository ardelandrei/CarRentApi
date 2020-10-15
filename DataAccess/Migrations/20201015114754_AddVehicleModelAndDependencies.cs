using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddVehicleModelAndDependencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManufacturerDetails",
                columns: table => new
                {
                    ManufacturerDetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VIN = table.Column<string>(maxLength: 17, nullable: false),
                    Mark = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    YearOfManufacture = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturerDetails", x => x.ManufacturerDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CanBeRented = table.Column<bool>(nullable: false),
                    RentPricePerHour = table.Column<decimal>(type: "decimal(10, 3)", nullable: false),
                    ManufacturerDetailsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_ManufacturerDetails_ManufacturerDetailsId",
                        column: x => x.ManufacturerDetailsId,
                        principalTable: "ManufacturerDetails",
                        principalColumn: "ManufacturerDetailsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ManufacturerDetailsId",
                table: "Vehicles",
                column: "ManufacturerDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "ManufacturerDetails");
        }
    }
}
