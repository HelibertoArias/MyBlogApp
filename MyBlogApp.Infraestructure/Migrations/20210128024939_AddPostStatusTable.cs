using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlogApp.Infraestructure.Migrations
{
    public partial class AddPostStatusTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_PostStatus_PostStatusId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostStatus",
                table: "PostStatus");

            migrationBuilder.RenameTable(
                name: "PostStatus",
                newName: "PostsStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostsStatus",
                table: "PostsStatus",
                column: "PostStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_PostsStatus_PostStatusId",
                table: "Posts",
                column: "PostStatusId",
                principalTable: "PostsStatus",
                principalColumn: "PostStatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_PostsStatus_PostStatusId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostsStatus",
                table: "PostsStatus");

            migrationBuilder.RenameTable(
                name: "PostsStatus",
                newName: "PostStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostStatus",
                table: "PostStatus",
                column: "PostStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_PostStatus_PostStatusId",
                table: "Posts",
                column: "PostStatusId",
                principalTable: "PostStatus",
                principalColumn: "PostStatusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
