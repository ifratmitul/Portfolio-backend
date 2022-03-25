using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class EduLogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogoId",
                table: "Schools",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Schools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Schools_LogoId",
                table: "Schools",
                column: "LogoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_Photos_LogoId",
                table: "Schools",
                column: "LogoId",
                principalTable: "Photos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schools_Photos_LogoId",
                table: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Schools_LogoId",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "LogoId",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Schools");
        }
    }
}
