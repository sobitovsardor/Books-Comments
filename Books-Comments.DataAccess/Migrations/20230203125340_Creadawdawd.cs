using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Books_Comments.DataAccess.Migrations
{
    public partial class Creadawdawd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Comments_CommentId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_CommentId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Comments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BookId",
                table: "Comments",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Books_BookId",
                table: "Comments",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Books_BookId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_BookId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Books",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_CommentId",
                table: "Books",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Comments_CommentId",
                table: "Books",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
