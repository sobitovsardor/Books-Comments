using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Books_Comments.DataAccess.Migrations
{
    public partial class Initialdawdad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Passwrod",
                table: "Users",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "Passwrod");
        }
    }
}
