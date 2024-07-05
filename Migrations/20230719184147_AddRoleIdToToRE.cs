using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndustrialContoroler.Migrations
{
    public partial class AddRoleIdToToRE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "Request",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Request");
        }
    }
}
