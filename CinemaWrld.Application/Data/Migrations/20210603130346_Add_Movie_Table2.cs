using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaWrld.Application.Data.Migrations
{
    public partial class Add_Movie_Table2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAgeRestricted",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAgeRestricted",
                table: "Movies");
        }
    }
}
