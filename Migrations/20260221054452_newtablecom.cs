using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iyde.Attendance.Variant3.Migrations
{
    /// <inheritdoc />
    public partial class newtablecom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Companies",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Companies",
                newName: "CompanyId");
        }
    }
}
