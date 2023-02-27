using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.EntityFramework.Migrations
{
    public partial class UniqueIndexNameStatusPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StatusPosts",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StatusPosts_Name",
                table: "StatusPosts",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StatusPosts_Name",
                table: "StatusPosts");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StatusPosts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
