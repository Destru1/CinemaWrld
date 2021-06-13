using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CinemaWrld.Application.Data.Migrations
{
    public partial class Add_Movie_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Cinemas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinemaId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    PremiereDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastProjectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cinemas_MovieId",
                table: "Cinemas",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CinemaId",
                table: "Movies",
                column: "CinemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Movies_MovieId",
                table: "Cinemas",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Movies_MovieId",
                table: "Cinemas");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Cinemas_MovieId",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Cinemas");
        }
    }
}
