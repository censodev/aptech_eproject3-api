using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfJoining",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RollNumber",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Section",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Specification",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Class",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateOfJoining",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RollNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Section",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Specification",
                table: "Users");
        }
    }
}
