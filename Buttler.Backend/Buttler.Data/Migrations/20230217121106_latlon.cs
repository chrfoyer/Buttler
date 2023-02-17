using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buttler.Data.Migrations
{
    /// <inheritdoc />
    public partial class latlon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "latitude",
                table: "Reports",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "longitude",
                table: "Reports",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "latitude",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "Reports");
        }
    }
}
