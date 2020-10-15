using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class RenameDateOfManufacture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YearOfManufacture",
                table: "ManufacturerDetails");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfManufacture",
                table: "ManufacturerDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfManufacture",
                table: "ManufacturerDetails");

            migrationBuilder.AddColumn<DateTime>(
                name: "YearOfManufacture",
                table: "ManufacturerDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
