using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Migrations
{
    public partial class ChangeValuesUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user_rango",
                table: "t_user",
                newName: "user_role");

            migrationBuilder.RenameColumn(
                name: "user_name",
                table: "t_user",
                newName: "user_last_name");

            migrationBuilder.AddColumn<string>(
                name: "user_first_name",
                table: "t_user",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "user_git",
                table: "t_user",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_first_name",
                table: "t_user");

            migrationBuilder.DropColumn(
                name: "user_git",
                table: "t_user");

            migrationBuilder.RenameColumn(
                name: "user_role",
                table: "t_user",
                newName: "user_rango");

            migrationBuilder.RenameColumn(
                name: "user_last_name",
                table: "t_user",
                newName: "user_name");
        }
    }
}
