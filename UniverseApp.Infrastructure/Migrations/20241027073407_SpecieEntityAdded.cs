using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniverseApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SpecieEntityAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Species_Characters_CharacterId",
                table: "Species");

            migrationBuilder.DropIndex(
                name: "IX_Species_CharacterId",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Species");

            migrationBuilder.AddColumn<string>(
                name: "AverageHeight",
                table: "Species",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                comment: "Specie Average Height");

            migrationBuilder.AddColumn<string>(
                name: "AverageLifespan",
                table: "Species",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                comment: "Specie Average Lifespan");

            migrationBuilder.AddColumn<string>(
                name: "Classification",
                table: "Species",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                comment: "Specie Classification");

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "Species",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                comment: "Specie Designation");

            migrationBuilder.AddColumn<string>(
                name: "EyeColors",
                table: "Species",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "Specie EyeColor");

            migrationBuilder.AddColumn<string>(
                name: "HairColors",
                table: "Species",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "Specie HairColor");

            migrationBuilder.AddColumn<string>(
                name: "Homeworld",
                table: "Species",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "Specie Homeworld");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Species",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                comment: "Specie Language");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Species",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                comment: "Specie Name");

            migrationBuilder.AddColumn<string>(
                name: "SkinColors",
                table: "Species",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "Specie SkinColor");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Species",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "",
                comment: "Specie Url");

            migrationBuilder.CreateTable(
                name: "CharacterSpecie",
                columns: table => new
                {
                    CharactersId = table.Column<int>(type: "int", nullable: false),
                    SpeciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSpecie", x => new { x.CharactersId, x.SpeciesId });
                    table.ForeignKey(
                        name: "FK_CharacterSpecie_Characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSpecie_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSpecie_SpeciesId",
                table: "CharacterSpecie",
                column: "SpeciesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterSpecie");

            migrationBuilder.DropColumn(
                name: "AverageHeight",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "AverageLifespan",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "Classification",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "EyeColors",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "HairColors",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "Homeworld",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "SkinColors",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Species");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Species",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Species_CharacterId",
                table: "Species",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Species_Characters_CharacterId",
                table: "Species",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id");
        }
    }
}
