using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class CertificateImprovement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogoId",
                table: "Certificates",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Certificates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Provider",
                table: "Certificates",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_LogoId",
                table: "Certificates",
                column: "LogoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_Photos_LogoId",
                table: "Certificates",
                column: "LogoId",
                principalTable: "Photos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_Photos_LogoId",
                table: "Certificates");

            migrationBuilder.DropIndex(
                name: "IX_Certificates_LogoId",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "LogoId",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "Provider",
                table: "Certificates");
        }
    }
}
