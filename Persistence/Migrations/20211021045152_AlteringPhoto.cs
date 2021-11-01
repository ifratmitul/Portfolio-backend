using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AlteringPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoUrl",
                table: "Skills",
                newName: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_PhotoId",
                table: "Skills",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Photos_PhotoId",
                table: "Skills",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Photos_PhotoId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_PhotoId",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "PhotoId",
                table: "Skills",
                newName: "PhotoUrl");
        }
    }
}
