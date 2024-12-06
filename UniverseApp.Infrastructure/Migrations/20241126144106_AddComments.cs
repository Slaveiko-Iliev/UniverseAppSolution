using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniverseApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "Vehicles",
                comment: "Vehicle Entity");

            migrationBuilder.AlterTable(
                name: "Starships",
                comment: "Starship Entity");

            migrationBuilder.AlterTable(
                name: "Species",
                comment: "Specie Entity");

            migrationBuilder.AlterTable(
                name: "Planets",
                comment: "Planet Entity");

            migrationBuilder.AlterTable(
                name: "Characters",
                comment: "Character Entity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "Vehicles",
                oldComment: "Vehicle Entity");

            migrationBuilder.AlterTable(
                name: "Starships",
                oldComment: "Starship Entity");

            migrationBuilder.AlterTable(
                name: "Species",
                oldComment: "Specie Entity");

            migrationBuilder.AlterTable(
                name: "Planets",
                oldComment: "Planet Entity");

            migrationBuilder.AlterTable(
                name: "Characters",
                oldComment: "Character Entity");
        }
    }
}
