using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iyde.Attendance.Variant3.Migrations
{
    /// <inheritdoc />
    public partial class chanework : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUser",
                table: "WorkDays",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedByUser",
                table: "WorkDays");
        }
    }
}
