using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Web.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class AddLikes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostTag_Tags_TagsID",
                table: "BlogPostTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlogPostID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Like_Posts_BlogPostID",
                        column: x => x.BlogPostID,
                        principalTable: "Posts",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Like_BlogPostID",
                table: "Like",
                column: "BlogPostID");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostTag_Tag_TagsID",
                table: "BlogPostTag",
                column: "TagsID",
                principalTable: "Tag",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostTag_Tag_TagsID",
                table: "BlogPostTag");

            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "Tags");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostTag_Tags_TagsID",
                table: "BlogPostTag",
                column: "TagsID",
                principalTable: "Tags",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
