using Microsoft.EntityFrameworkCore.Migrations;

namespace SnippetManagerData.Migrations
{
    public partial class ChangeSnippet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Environments",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    UserID = table.Column<string>(type: "TEXT", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Environments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "OperatingSystems",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    UserID = table.Column<string>(type: "TEXT", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingSystems", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Snippets",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Environmentid = table.Column<int>(type: "INTEGER", nullable: true),
                    OperatingSystemid = table.Column<int>(type: "INTEGER", nullable: true),
                    UserID = table.Column<string>(type: "TEXT", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snippets", x => x.id);
                    table.ForeignKey(
                        name: "FK_Snippets_Environments_Environmentid",
                        column: x => x.Environmentid,
                        principalTable: "Environments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Snippets_OperatingSystems_OperatingSystemid",
                        column: x => x.OperatingSystemid,
                        principalTable: "OperatingSystems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Snippets_Environmentid",
                table: "Snippets",
                column: "Environmentid");

            migrationBuilder.CreateIndex(
                name: "IX_Snippets_OperatingSystemid",
                table: "Snippets",
                column: "OperatingSystemid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Snippets");

            migrationBuilder.DropTable(
                name: "Environments");

            migrationBuilder.DropTable(
                name: "OperatingSystems");
        }
    }
}
