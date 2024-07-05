using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndustrialContoroler.Migrations
{
    public partial class EditNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FaId",
                table: "Notis",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReId",
                table: "Notis",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notis_FaId",
                table: "Notis",
                column: "FaId");

            migrationBuilder.CreateIndex(
                name: "IX_Notis_ReId",
                table: "Notis",
                column: "ReId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notis_Facility_FaId",
                table: "Notis",
                column: "FaId",
                principalTable: "Facility",
                principalColumn: "fa_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notis_Request_ReId",
                table: "Notis",
                column: "ReId",
                principalTable: "Request",
                principalColumn: "re_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notis_Facility_FaId",
                table: "Notis");

            migrationBuilder.DropForeignKey(
                name: "FK_Notis_Request_ReId",
                table: "Notis");

            migrationBuilder.DropIndex(
                name: "IX_Notis_FaId",
                table: "Notis");

            migrationBuilder.DropIndex(
                name: "IX_Notis_ReId",
                table: "Notis");

            migrationBuilder.DropColumn(
                name: "FaId",
                table: "Notis");

            migrationBuilder.DropColumn(
                name: "ReId",
                table: "Notis");
        }
    }
}
