using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iyde.Attendance.Variant3.Migrations
{
    /// <inheritdoc />
    public partial class chane : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Stores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "appUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stores_CompanyId",
                table: "Stores",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Companies_CompanyId",
                table: "Stores",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Companies_CompanyId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_CompanyId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "appUsers");
        }
    }
}
