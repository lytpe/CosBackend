using Microsoft.EntityFrameworkCore.Migrations;

namespace Cos.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArticleName = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    ArticleSideName = table.Column<string>(nullable: true),
                    ArticleContext = table.Column<string>(nullable: true),
                    ArticleCreateDate = table.Column<string>(nullable: true),
                    ArticleUpdateDate = table.Column<string>(nullable: true),
                    ArticleImgUrl = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Me",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Infos = table.Column<string>(nullable: true),
                    SubmitDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Me", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PicName = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    ImgSubmitDate = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Si",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArticleContext = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    ArticleCreateDate = table.Column<string>(nullable: true),
                    ArticleImgUrl = table.Column<string>(nullable: true),
                    ArticleUpdateDate = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Si", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ar");

            migrationBuilder.DropTable(
                name: "Me");

            migrationBuilder.DropTable(
                name: "Sc");

            migrationBuilder.DropTable(
                name: "Si");
        }
    }
}
