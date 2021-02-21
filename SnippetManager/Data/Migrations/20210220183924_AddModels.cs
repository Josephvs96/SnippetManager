using Microsoft.EntityFrameworkCore.Migrations;

namespace SnippetManager.Data.Migrations
{
    public partial class AddModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Environments",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    OSName = table.Column<string>(maxLength: 50, nullable: false),
                    UserID = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Environments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Snippets",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Code = table.Column<string>(nullable: false),
                    Environmentid = table.Column<int>(nullable: false),
                    UserID = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snippets", x => x.id);
                    table.ForeignKey(
                        name: "FK_Snippets_Environments_Environmentid",
                        column: x => x.Environmentid,
                        principalTable: "Environments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Snippets_Environmentid",
                table: "Snippets",
                column: "Environmentid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Snippets");

            migrationBuilder.DropTable(
                name: "Environments");
        }
    }
}
