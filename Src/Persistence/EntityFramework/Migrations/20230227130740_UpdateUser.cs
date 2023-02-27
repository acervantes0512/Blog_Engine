using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.EntityFramework.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EditPostUsers_Posts_PostId",
                table: "EditPostUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_EditPostUsers_Users_UserAuthorId",
                table: "EditPostUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserAuthorId",
                table: "EditPostUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "EditPostUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostId1",
                table: "EditPostUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "EditPostUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EditPostUsers_PostId1",
                table: "EditPostUsers",
                column: "PostId1");

            migrationBuilder.CreateIndex(
                name: "IX_EditPostUsers_UserId",
                table: "EditPostUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EditPostUsers_Posts_PostId",
                table: "EditPostUsers",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EditPostUsers_Posts_PostId1",
                table: "EditPostUsers",
                column: "PostId1",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EditPostUsers_Users_UserAuthorId",
                table: "EditPostUsers",
                column: "UserAuthorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EditPostUsers_Users_UserId",
                table: "EditPostUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EditPostUsers_Posts_PostId",
                table: "EditPostUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_EditPostUsers_Posts_PostId1",
                table: "EditPostUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_EditPostUsers_Users_UserAuthorId",
                table: "EditPostUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_EditPostUsers_Users_UserId",
                table: "EditPostUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Username",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_EditPostUsers_PostId1",
                table: "EditPostUsers");

            migrationBuilder.DropIndex(
                name: "IX_EditPostUsers_UserId",
                table: "EditPostUsers");

            migrationBuilder.DropColumn(
                name: "PostId1",
                table: "EditPostUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "EditPostUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "UserAuthorId",
                table: "EditPostUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "EditPostUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_EditPostUsers_Posts_PostId",
                table: "EditPostUsers",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EditPostUsers_Users_UserAuthorId",
                table: "EditPostUsers",
                column: "UserAuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
