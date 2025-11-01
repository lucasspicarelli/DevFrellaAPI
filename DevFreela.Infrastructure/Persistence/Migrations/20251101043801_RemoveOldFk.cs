using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevFreela.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveOldFk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectComment_Users_UserId",
                table: "ProjectComment");

            migrationBuilder.DropIndex(
                name: "IX_ProjectComment_UserId",
                table: "ProjectComment");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProjectComment");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectComment_IdUser",
                table: "ProjectComment",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectComment_Users_IdUser",
                table: "ProjectComment",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectComment_Users_IdUser",
                table: "ProjectComment");

            migrationBuilder.DropIndex(
                name: "IX_ProjectComment_IdUser",
                table: "ProjectComment");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ProjectComment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectComment_UserId",
                table: "ProjectComment",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectComment_Users_UserId",
                table: "ProjectComment",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
