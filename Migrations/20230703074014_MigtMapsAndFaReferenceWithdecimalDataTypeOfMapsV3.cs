using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndustrialContoroler.Migrations
{
    public partial class MigtMapsAndFaReferenceWithdecimalDataTypeOfMapsV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Facility",
                newName: "FaLongitude");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "Facility",
                newName: "FaLatitude");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FaLongitude",
                table: "Facility",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "FaLatitude",
                table: "Facility",
                newName: "Latitude");
        }
    }
}
