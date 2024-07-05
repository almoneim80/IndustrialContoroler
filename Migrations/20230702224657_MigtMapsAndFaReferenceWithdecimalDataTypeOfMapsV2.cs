using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndustrialContoroler.Migrations
{
    public partial class MigtMapsAndFaReferenceWithdecimalDataTypeOfMapsV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ__Request__44C63773E9ED83A5",
                table: "Request");

            migrationBuilder.AlterColumn<int>(
                name: "re_suemNo",
                table: "Request",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "re_Date",
                table: "Request",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Facility",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Facility",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "UQ__Request__44C63773E9ED83A5",
                table: "Request",
                column: "re_suemNo",
                unique: true,
                filter: "[re_suemNo] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ__Request__44C63773E9ED83A5",
                table: "Request");

            migrationBuilder.AlterColumn<int>(
                name: "re_suemNo",
                table: "Request",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "re_Date",
                table: "Request",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Longitude",
                table: "Facility",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Latitude",
                table: "Facility",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateIndex(
                name: "UQ__Request__44C63773E9ED83A5",
                table: "Request",
                column: "re_suemNo",
                unique: true);
        }
    }
}
