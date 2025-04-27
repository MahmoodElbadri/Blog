using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Web.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class UpdateLikes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostTag_Tag_TagsID",
                table: "BlogPostTag");

            migrationBuilder.DropForeignKey(
                name: "FK_Like_Posts_BlogPostID",
                table: "Like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Like",
                table: "Like");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "Tags");

            migrationBuilder.RenameTable(
                name: "Like",
                newName: "Likes");

            migrationBuilder.RenameIndex(
                name: "IX_Like_BlogPostID",
                table: "Likes",
                newName: "IX_Likes_BlogPostID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostTag_Tags_TagsID",
                table: "BlogPostTag",
                column: "TagsID",
                principalTable: "Tags",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Posts_BlogPostID",
                table: "Likes",
                column: "BlogPostID",
                principalTable: "Posts",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostTag_Tags_TagsID",
                table: "BlogPostTag");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Posts_BlogPostID",
                table: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.RenameTable(
                name: "Likes",
                newName: "Like");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_BlogPostID",
                table: "Like",
                newName: "IX_Like_BlogPostID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Like",
                table: "Like",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostTag_Tag_TagsID",
                table: "BlogPostTag",
                column: "TagsID",
                principalTable: "Tag",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Posts_BlogPostID",
                table: "Like",
                column: "BlogPostID",
                principalTable: "Posts",
                principalColumn: "ID");
        }
    }
}
