using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniverseApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedMovieEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Movie Identifier"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Movie Title"),
                    EpisodeId = table.Column<int>(type: "int", nullable: false, comment: "Movie Episode Identifier"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Movie Description"),
                    Director = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Movie Director"),
                    Producer = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Movie Producer"),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Movie Release Date")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                },
                comment: "Movie Entity");

            migrationBuilder.CreateTable(
                name: "CharactersMovies",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false, comment: "Character Identifier"),
                    MovieId = table.Column<int>(type: "int", nullable: false, comment: "Movie Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharactersMovies", x => new { x.CharacterId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_CharactersMovies_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharactersMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "CharactersMovies Entity");

            migrationBuilder.CreateIndex(
                name: "IX_CharactersMovies_MovieId",
                table: "CharactersMovies",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharactersMovies");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
