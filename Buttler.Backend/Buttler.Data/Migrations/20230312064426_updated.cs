using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buttler.Data.Migrations
{
    /// <inheritdoc />
    public partial class updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userName",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "passWord",
                table: "Users",
                newName: "PassWord");

            migrationBuilder.RenameColumn(
                name: "dateCreated",
                table: "Users",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "Users",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "longitude",
                table: "Reports",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "latitude",
                table: "Reports",
                newName: "Latitude");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Reports",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "userName");

            migrationBuilder.RenameColumn(
                name: "PassWord",
                table: "Users",
                newName: "passWord");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Users",
                newName: "dateCreated");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Users",
                newName: "userID");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Reports",
                newName: "longitude");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "Reports",
                newName: "latitude");
        }
    }
}
