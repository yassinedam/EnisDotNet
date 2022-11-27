using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENISdotNet.Migrations
{
    public partial class _555 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_sections_SectionId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "SectionId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_sections_SectionId",
                table: "Users",
                column: "SectionId",
                principalTable: "sections",
                principalColumn: "SectionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_sections_SectionId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "SectionId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_sections_SectionId",
                table: "Users",
                column: "SectionId",
                principalTable: "sections",
                principalColumn: "SectionId");
        }
    }
}
