using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndustrialContoroler.Migrations
{
    public partial class AddLogFild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "LogFieldVisitFormsLogId",
                table: "Notification",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LogFieldVisitForms",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogFieldVisitForms", x => x.LogId);
                    table.ForeignKey(
                        name: "FK_LogFieldVisitForms_Facility_FaId",
                        column: x => x.FaId,
                        principalTable: "Facility",
                        principalColumn: "fa_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notification_LogFieldVisitFormsLogId",
                table: "Notification",
                column: "LogFieldVisitFormsLogId");

            migrationBuilder.CreateIndex(
                name: "IX_LogFieldVisitForms_FaId",
                table: "LogFieldVisitForms",
                column: "FaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_LogFieldVisitForms_LogFieldVisitFormsLogId",
                table: "Notification",
                column: "LogFieldVisitFormsLogId",
                principalTable: "LogFieldVisitForms",
                principalColumn: "LogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_LogFieldVisitForms_LogFieldVisitFormsLogId",
                table: "Notification");

            migrationBuilder.DropTable(
                name: "LogFieldVisitForms");

            migrationBuilder.DropIndex(
                name: "IX_Notification_LogFieldVisitFormsLogId",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "LogFieldVisitFormsLogId",
                table: "Notification");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogCategories_CategoryId",
                table: "LogCategories",
                column: "CategoryId");
        }
    }
}
