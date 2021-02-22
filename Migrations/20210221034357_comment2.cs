using Microsoft.EntityFrameworkCore.Migrations;

namespace PostsBaord.Migrations
{
    public partial class comment2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_PostComment_PostCommentID",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_PostCommentID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostCommentID",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "PostsID",
                table: "PostComment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostComment_PostsID",
                table: "PostComment",
                column: "PostsID");

            migrationBuilder.AddForeignKey(
                name: "FK_PostComment_Posts_PostsID",
                table: "PostComment",
                column: "PostsID",
                principalTable: "Posts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostComment_Posts_PostsID",
                table: "PostComment");

            migrationBuilder.DropIndex(
                name: "IX_PostComment_PostsID",
                table: "PostComment");

            migrationBuilder.DropColumn(
                name: "PostsID",
                table: "PostComment");

            migrationBuilder.AddColumn<int>(
                name: "PostCommentID",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostCommentID",
                table: "Posts",
                column: "PostCommentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_PostComment_PostCommentID",
                table: "Posts",
                column: "PostCommentID",
                principalTable: "PostComment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
