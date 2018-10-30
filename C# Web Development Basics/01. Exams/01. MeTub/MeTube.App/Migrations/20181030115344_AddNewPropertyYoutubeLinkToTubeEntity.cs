using Microsoft.EntityFrameworkCore.Migrations;

namespace MeTube.App.Migrations
{
    public partial class AddNewPropertyYoutubeLinkToTubeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "YoutubeLink",
                table: "Tubes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YoutubeLink",
                table: "Tubes");
        }
    }
}
