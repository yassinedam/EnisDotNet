using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENISdotNet.Migrations
{
    public partial class _13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_demandes_Users_UserId",
                table: "demandes");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "demandes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_demandes_Users_UserId",
                table: "demandes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_demandes_Users_UserId",
                table: "demandes");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "demandes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_demandes_Users_UserId",
                table: "demandes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
