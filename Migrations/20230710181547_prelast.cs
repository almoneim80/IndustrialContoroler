using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndustrialContoroler.Migrations
{
    public partial class prelast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "re_reference",
                table: "Request");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "re_reference",
                table: "Request",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
