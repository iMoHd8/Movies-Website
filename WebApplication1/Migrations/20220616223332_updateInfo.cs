using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class updateInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userEmail",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "userName",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "userPassword",
                table: "Members",
                newName: "name");

            migrationBuilder.AddColumn<string>(
                name: "confirmPassword",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "confirmPassword",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "email",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "password",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Members",
                newName: "userPassword");

            migrationBuilder.AddColumn<string>(
                name: "userEmail",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userName",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
