using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENISdotNet.Migrations
{
    public partial class vf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "demandes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    demanded_at = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    approved_at = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_demandes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "departements",
                columns: table => new
                {
                    DepartementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    spacialitée = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departements", x => x.DepartementId);
                });

            migrationBuilder.CreateTable(
                name: "papers",
                columns: table => new
                {
                    paperId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Staus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    demanded_at = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    approved_at = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_papers", x => x.paperId);
                });

            migrationBuilder.CreateTable(
                name: "sections",
                columns: table => new
                {
                    SectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sectionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    schoolYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sections", x => x.SectionId);
                    table.ForeignKey(
                        name: "FK_sections_departements_DepartementId",
                        column: x => x.DepartementId,
                        principalTable: "departements",
                        principalColumn: "DepartementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumber = table.Column<int>(type: "int", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    paperId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_papers_paperId",
                        column: x => x.paperId,
                        principalTable: "papers",
                        principalColumn: "paperId");
                    table.ForeignKey(
                        name: "FK_Users_sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "sections",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DemandePFEUser",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    demandesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandePFEUser", x => new { x.UserId, x.demandesId });
                    table.ForeignKey(
                        name: "FK_DemandePFEUser_demandes_demandesId",
                        column: x => x.demandesId,
                        principalTable: "demandes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DemandePFEUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DemandePFEUser_demandesId",
                table: "DemandePFEUser",
                column: "demandesId");

            migrationBuilder.CreateIndex(
                name: "IX_sections_DepartementId",
                table: "sections",
                column: "DepartementId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_paperId",
                table: "Users",
                column: "paperId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SectionId",
                table: "Users",
                column: "SectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DemandePFEUser");

            migrationBuilder.DropTable(
                name: "demandes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "papers");

            migrationBuilder.DropTable(
                name: "sections");

            migrationBuilder.DropTable(
                name: "departements");
        }
    }
}
