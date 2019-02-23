using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Migrations
{
    public partial class AzureInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_user",
                columns: table => new
                {
                    user_id = table.Column<Guid>(nullable: false),
                    user_first_name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    user_last_name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    user_git = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    user_email = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    user_role = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    user_phone = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    user_address = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    user_photo = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    user_web = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "t_blog",
                columns: table => new
                {
                    publ_id = table.Column<Guid>(nullable: false),
                    publ_name = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    publ_desc = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    publ_body = table.Column<string>(unicode: false, maxLength: 5000, nullable: true),
                    publ_etiq = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    publ_calif = table.Column<int>(unicode: false, maxLength: 200, nullable: true),
                    publ_date = table.Column<DateTime>(type: "date", nullable: true),
                    fk_t_user_user_id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_blog", x => x.publ_id);
                    table.ForeignKey(
                        name: "FK_t_blog_t_user1",
                        column: x => x.fk_t_user_user_id,
                        principalTable: "t_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_producto",
                columns: table => new
                {
                    prod_id = table.Column<Guid>(nullable: false),
                    prod_name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    prod_cod = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    prod_desc = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    prod_stock = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    prod_brand = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    prod_price = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    fk_user_user_id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_producto", x => x.prod_id);
                    table.ForeignKey(
                        name: "FK_t_producto_t_user",
                        column: x => x.fk_user_user_id,
                        principalTable: "t_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_proyectos",
                columns: table => new
                {
                    proy_id = table.Column<Guid>(nullable: false),
                    proy_title = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    proy_desc = table.Column<string>(unicode: false, maxLength: 300, nullable: true),
                    proy_date = table.Column<DateTime>(type: "date", nullable: true),
                    fk_t_user_user_id = table.Column<Guid>(nullable: true),
                    proy_url = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_proyectos", x => x.proy_id);
                    table.ForeignKey(
                        name: "FK_t_proyectos_t_user1",
                        column: x => x.fk_t_user_user_id,
                        principalTable: "t_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_images",
                columns: table => new
                {
                    image_id = table.Column<Guid>(nullable: false),
                    image_name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    image_url = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    fk_t_producto_prod_id = table.Column<Guid>(nullable: true),
                    fk_t_blog_publ_id = table.Column<Guid>(nullable: true),
                    fk_t_proy_proy_id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_images", x => x.image_id);
                    table.ForeignKey(
                        name: "FK_t_images_t_blog",
                        column: x => x.fk_t_blog_publ_id,
                        principalTable: "t_blog",
                        principalColumn: "publ_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_images_t_producto",
                        column: x => x.fk_t_producto_prod_id,
                        principalTable: "t_producto",
                        principalColumn: "prod_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_images_t_proyectos",
                        column: x => x.fk_t_proy_proy_id,
                        principalTable: "t_proyectos",
                        principalColumn: "proy_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_blog_fk_t_user_user_id",
                table: "t_blog",
                column: "fk_t_user_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_images_fk_t_blog_publ_id",
                table: "t_images",
                column: "fk_t_blog_publ_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_images_fk_t_producto_prod_id",
                table: "t_images",
                column: "fk_t_producto_prod_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_images_fk_t_proy_proy_id",
                table: "t_images",
                column: "fk_t_proy_proy_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_producto_fk_user_user_id",
                table: "t_producto",
                column: "fk_user_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_proyectos_fk_t_user_user_id",
                table: "t_proyectos",
                column: "fk_t_user_user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_images");

            migrationBuilder.DropTable(
                name: "t_blog");

            migrationBuilder.DropTable(
                name: "t_producto");

            migrationBuilder.DropTable(
                name: "t_proyectos");

            migrationBuilder.DropTable(
                name: "t_user");
        }
    }
}
