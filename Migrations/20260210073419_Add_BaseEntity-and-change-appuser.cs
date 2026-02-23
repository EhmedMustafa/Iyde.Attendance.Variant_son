using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iyde.Attendance.Variant3.Migrations
{
    /// <inheritdoc />
    public partial class Add_BaseEntityandchangeappuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "appUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "appUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "appUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "appUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "appUsers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "appUsers");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "appUsers");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "appUsers");
        }
    }
}
