using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENISdotNet.Migrations
{
    public partial class _666 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_papers_paperId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_sections_SectionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_paperId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "paperId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "SectionId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "PaperUser",
                columns: table => new
                {
                    paperspaperId = table.Column<int>(type: "int", nullable: false),
                    usersUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaperUser", x => new { x.paperspaperId, x.usersUserId });
                    table.ForeignKey(
                        name: "FK_PaperUser_papers_paperspaperId",
                        column: x => x.paperspaperId,
                        principalTable: "papers",
                        principalColumn: "paperId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaperUser_Users_usersUserId",
                        column: x => x.usersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaperUser_usersUserId",
                table: "PaperUser",
                column: "usersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_sections_SectionId",
                table: "Users",
                column: "SectionId",
                principalTable: "sections",
                principalColumn: "SectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_sections_SectionId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "PaperUser");

            migrationBuilder.AlterColumn<int>(
                name: "SectionId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "paperId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_paperId",
                table: "Users",
                column: "paperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_papers_paperId",
                table: "Users",
                column: "paperId",
                principalTable: "papers",
                principalColumn: "paperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_sections_SectionId",
                table: "Users",
                column: "SectionId",
                principalTable: "sections",
                principalColumn: "SectionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
