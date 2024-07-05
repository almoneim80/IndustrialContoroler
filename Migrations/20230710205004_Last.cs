using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndustrialContoroler.Migrations
{
    public partial class Last : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rt_endDate",
                table: "requestTraffic");

            migrationBuilder.DropColumn(
                name: "rt_startDate",
                table: "requestTraffic");

            migrationBuilder.DropColumn(
                name: "us_Id",
                table: "requestTraffic");

            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "requestTraffic",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "requestTraffic",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "requestTraffic",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Action",
                table: "requestTraffic");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "requestTraffic");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "requestTraffic");

            migrationBuilder.AddColumn<DateTime>(
                name: "rt_endDate",
                table: "requestTraffic",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "rt_startDate",
                table: "requestTraffic",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "us_Id",
                table: "requestTraffic",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
