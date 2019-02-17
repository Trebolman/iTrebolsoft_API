using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Migrations
{
    public partial class updateColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProyUrl",
                table: "t_proyectos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PublCalif",
                table: "t_blog",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PublEtiq",
                table: "t_blog",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProyUrl",
                table: "t_proyectos");

            migrationBuilder.DropColumn(
                name: "PublCalif",
                table: "t_blog");

            migrationBuilder.DropColumn(
                name: "PublEtiq",
                table: "t_blog");
        }
    }
}
