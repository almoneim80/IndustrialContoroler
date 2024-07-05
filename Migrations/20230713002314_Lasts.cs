using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndustrialContoroler.Migrations
{
    public partial class Lasts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notis_Request_ReId",
                table: "Notis");

            migrationBuilder.DropIndex(
                name: "IX_Notis_ReId",
                table: "Notis");

            migrationBuilder.DropColumn(
                name: "ReId",
                table: "Notis");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReId",
                table: "Notis",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notis_ReId",
                table: "Notis",
                column: "ReId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notis_Request_ReId",
                table: "Notis",
                column: "ReId",
                principalTable: "Request",
                principalColumn: "re_Id");
        }
    }
}
