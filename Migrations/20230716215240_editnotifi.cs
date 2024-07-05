using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndustrialContoroler.Migrations
{
    public partial class editnotifi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "Request",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Notis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Notis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "Facility",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Facility");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Notis",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Notis",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    no_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    requestTraffic_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false),
                    LogFieldVisitFormsLogId = table.Column<int>(type: "int", nullable: true),
                    no_date = table.Column<DateTime>(type: "date", nullable: false),
                    no_Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    no_Sourse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    no_time = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__E2D318E83F3B1F73", x => x.no_Id);
                    table.ForeignKey(
                        name: "FK_Notification_LogFieldVisitForms_LogFieldVisitFormsLogId",
                        column: x => x.LogFieldVisitFormsLogId,
                        principalTable: "LogFieldVisitForms",
                        principalColumn: "LogId");
                    table.ForeignKey(
                        name: "FK_requestTrafficNotifications",
                        column: x => x.requestTraffic_Id,
                        principalTable: "requestTraffic",
                        principalColumn: "rt_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notification_LogFieldVisitFormsLogId",
                table: "Notification",
                column: "LogFieldVisitFormsLogId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_requestTraffic_Id",
                table: "Notification",
                column: "requestTraffic_Id");
        }
    }
}
