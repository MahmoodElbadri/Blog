using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Web.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class EditingComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comments",
                newName: "ID");

            migrationBuilder.AddColumn<Guid>(
                name: "UserID",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Comments",
                newName: "Id");
        }
    }
}
