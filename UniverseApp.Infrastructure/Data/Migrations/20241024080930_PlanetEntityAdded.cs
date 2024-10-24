using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniverseApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class PlanetEntityAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movies",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                comment: "Movie Title",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Movie Title");

            migrationBuilder.AlterColumn<string>(
                name: "Producer",
                table: "Movies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Movie Producer",
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40,
                oldComment: "Movie Producer");

            migrationBuilder.AlterColumn<string>(
                name: "Director",
                table: "Movies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Movie Director",
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40,
                oldComment: "Movie Director");

            migrationBuilder.AddColumn<int>(
                name: "PlanetId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlanetId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Movie Identifier"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RotationPeriod = table.Column<int>(type: "int", maxLength: 50, nullable: true),
                    OrbitalPeriod = table.Column<int>(type: "int", maxLength: 50, nullable: true),
                    Climate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gravity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SurfaceWater = table.Column<decimal>(type: "decimal(5,2)", maxLength: 50, nullable: true),
                    Population = table.Column<int>(type: "int", maxLength: 50, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_PlanetId",
                table: "Movies",
                column: "PlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_PlanetId",
                table: "Characters",
                column: "PlanetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Planets_PlanetId",
                table: "Characters",
                column: "PlanetId",
                principalTable: "Planets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Planets_PlanetId",
                table: "Movies",
                column: "PlanetId",
                principalTable: "Planets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Planets_PlanetId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Planets_PlanetId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Planets");

            migrationBuilder.DropIndex(
                name: "IX_Movies_PlanetId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Characters_PlanetId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "PlanetId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "PlanetId",
                table: "Characters");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Movie Title",
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60,
                oldComment: "Movie Title");

            migrationBuilder.AlterColumn<string>(
                name: "Producer",
                table: "Movies",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                comment: "Movie Producer",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Movie Producer");

            migrationBuilder.AlterColumn<string>(
                name: "Director",
                table: "Movies",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                comment: "Movie Director",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Movie Director");
        }
    }
}
