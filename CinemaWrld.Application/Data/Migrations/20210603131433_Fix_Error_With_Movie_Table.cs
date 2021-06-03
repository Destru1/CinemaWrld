using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaWrld.Application.Data.Migrations
{
    public partial class Fix_Error_With_Movie_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Movies_MovieId",
                table: "Cinemas");

            migrationBuilder.DropIndex(
                name: "IX_Cinemas_MovieId",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Cinemas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Cinemas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cinemas_MovieId",
                table: "Cinemas",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Movies_MovieId",
                table: "Cinemas",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
