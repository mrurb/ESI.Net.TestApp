using Microsoft.EntityFrameworkCore.Migrations;

namespace ESI.Net.TestApp.Data.Migrations
{
    public partial class Applicationuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CharID",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CharID",
                table: "AspNetUsers");
        }
    }
}
