using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaWrld.Application.Data.Migrations
{
    public partial class Add_Votes_To_Movie_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Votes",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Votes",
                table: "Movies");
        }
    }
}
