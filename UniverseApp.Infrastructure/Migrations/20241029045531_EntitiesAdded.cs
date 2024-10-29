using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniverseApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EntitiesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Species_Characters_CharacterId",
                table: "Species");

            migrationBuilder.DropForeignKey(
                name: "FK_Starships_Characters_CharacterId",
                table: "Starships");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Characters_CharacterId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_CharacterId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Starships_CharacterId",
                table: "Starships");

            migrationBuilder.DropIndex(
                name: "IX_Species_CharacterId",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Starships");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Species");

            migrationBuilder.AddColumn<int>(
                name: "CargoCapacity",
                table: "Vehicles",
                type: "int",
                maxLength: 15,
                nullable: true,
                comment: "Vehicle Cargo Capacity");

            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "Vehicles",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                comment: "Vehicle Class");

            migrationBuilder.AddColumn<string>(
                name: "Consumables",
                table: "Vehicles",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "Vehicle Consumables");

            migrationBuilder.AddColumn<int>(
                name: "CostInCredits",
                table: "Vehicles",
                type: "int",
                maxLength: 15,
                nullable: true,
                comment: "Vehicle Cost In Credits");

            migrationBuilder.AddColumn<int>(
                name: "Crew",
                table: "Vehicles",
                type: "int",
                maxLength: 10,
                nullable: true,
                comment: "Vehicle Crew");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Whether the Entity has been deleted");

            migrationBuilder.AddColumn<double>(
                name: "Length",
                table: "Vehicles",
                type: "float",
                maxLength: 7,
                nullable: true,
                comment: "Vehicle Length");

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Vehicles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "Vehicle Manufacturer");

            migrationBuilder.AddColumn<int>(
                name: "MaxAtmospheringSpeed",
                table: "Vehicles",
                type: "int",
                maxLength: 4,
                nullable: true,
                comment: "Vehicle Max Atmosphering Speed");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Vehicles",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true,
                comment: "Vehicle Model");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Vehicles",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                comment: "Vehicle Name");

            migrationBuilder.AddColumn<int>(
                name: "Passengers",
                table: "Vehicles",
                type: "int",
                maxLength: 10,
                nullable: true,
                comment: "Vehicle Passengers");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Vehicles",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "",
                comment: "Vehicle URL");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Starships",
                type: "int",
                nullable: false,
                comment: "Vehicle Identifier",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Starship Identifier");

            migrationBuilder.AddColumn<int>(
                name: "CargoCapacity",
                table: "Starships",
                type: "int",
                maxLength: 15,
                nullable: true,
                comment: "Vehicle Cargo Capacity");

            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "Starships",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                comment: "Vehicle Class");

            migrationBuilder.AddColumn<string>(
                name: "Consumables",
                table: "Starships",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "Vehicle Consumables");

            migrationBuilder.AddColumn<int>(
                name: "CostInCredits",
                table: "Starships",
                type: "int",
                maxLength: 15,
                nullable: true,
                comment: "Vehicle Cost In Credits");

            migrationBuilder.AddColumn<int>(
                name: "Crew",
                table: "Starships",
                type: "int",
                maxLength: 10,
                nullable: true,
                comment: "Vehicle Crew");

            migrationBuilder.AddColumn<double>(
                name: "HyperdriveRating",
                table: "Starships",
                type: "float",
                maxLength: 3,
                nullable: true,
                comment: "Starship Hyperdrive Rating");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Starships",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Whether the Entity has been deleted");

            migrationBuilder.AddColumn<double>(
                name: "Length",
                table: "Starships",
                type: "float",
                maxLength: 7,
                nullable: true,
                comment: "Vehicle Length");

            migrationBuilder.AddColumn<int>(
                name: "MGLT",
                table: "Starships",
                type: "int",
                maxLength: 3,
                nullable: true,
                comment: "Starship MGLT");

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Starships",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "Vehicle Manufacturer");

            migrationBuilder.AddColumn<int>(
                name: "MaxAtmospheringSpeed",
                table: "Starships",
                type: "int",
                maxLength: 4,
                nullable: true,
                comment: "Vehicle Max Atmosphering Speed");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Starships",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true,
                comment: "Vehicle Model");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Starships",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                comment: "Vehicle Name");

            migrationBuilder.AddColumn<int>(
                name: "Passengers",
                table: "Starships",
                type: "int",
                maxLength: 10,
                nullable: true,
                comment: "Vehicle Passengers");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Starships",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "",
                comment: "Vehicle URL");

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

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Species",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Whether the Entity has been deleted");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Species",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                comment: "Specie Name");

            migrationBuilder.AddColumn<int>(
                name: "PlanetId",
                table: "Species",
                type: "int",
                maxLength: 50,
                nullable: true,
                comment: "Specie Homeworld");

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

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Planets",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Whether the Entity has been deleted");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Whether the Entity has been deleted");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Characters",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Whether the Entity has been deleted");

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

            migrationBuilder.CreateTable(
                name: "CharacterStarship",
                columns: table => new
                {
                    CharactersId = table.Column<int>(type: "int", nullable: false),
                    StarshipsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterStarship", x => new { x.CharactersId, x.StarshipsId });
                    table.ForeignKey(
                        name: "FK_CharacterStarship_Characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterStarship_Starships_StarshipsId",
                        column: x => x.StarshipsId,
                        principalTable: "Starships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterVehicle",
                columns: table => new
                {
                    CharactersId = table.Column<int>(type: "int", nullable: false),
                    VehiclesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterVehicle", x => new { x.CharactersId, x.VehiclesId });
                    table.ForeignKey(
                        name: "FK_CharacterVehicle_Characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterVehicle_Vehicles_VehiclesId",
                        column: x => x.VehiclesId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Species_PlanetId",
                table: "Species",
                column: "PlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSpecie_SpeciesId",
                table: "CharacterSpecie",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterStarship_StarshipsId",
                table: "CharacterStarship",
                column: "StarshipsId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterVehicle_VehiclesId",
                table: "CharacterVehicle",
                column: "VehiclesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Species_Planets_PlanetId",
                table: "Species",
                column: "PlanetId",
                principalTable: "Planets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Species_Planets_PlanetId",
                table: "Species");

            migrationBuilder.DropTable(
                name: "CharacterSpecie");

            migrationBuilder.DropTable(
                name: "CharacterStarship");

            migrationBuilder.DropTable(
                name: "CharacterVehicle");

            migrationBuilder.DropIndex(
                name: "IX_Species_PlanetId",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "CargoCapacity",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Class",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Consumables",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "CostInCredits",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Crew",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "MaxAtmospheringSpeed",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Passengers",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "CargoCapacity",
                table: "Starships");

            migrationBuilder.DropColumn(
                name: "Class",
                table: "Starships");

            migrationBuilder.DropColumn(
                name: "Consumables",
                table: "Starships");

            migrationBuilder.DropColumn(
                name: "CostInCredits",
                table: "Starships");

            migrationBuilder.DropColumn(
                name: "Crew",
                table: "Starships");

            migrationBuilder.DropColumn(
                name: "HyperdriveRating",
                table: "Starships");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Starships");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Starships");

            migrationBuilder.DropColumn(
                name: "MGLT",
                table: "Starships");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Starships");

            migrationBuilder.DropColumn(
                name: "MaxAtmospheringSpeed",
                table: "Starships");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Starships");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Starships");

            migrationBuilder.DropColumn(
                name: "Passengers",
                table: "Starships");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Starships");

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
                name: "IsDeleted",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "PlanetId",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "SkinColors",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Characters");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Vehicles",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Starships",
                type: "int",
                nullable: false,
                comment: "Starship Identifier",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Vehicle Identifier");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Starships",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Species",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CharacterId",
                table: "Vehicles",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Starships_CharacterId",
                table: "Starships",
                column: "CharacterId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Starships_Characters_CharacterId",
                table: "Starships",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Characters_CharacterId",
                table: "Vehicles",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id");
        }
    }
}
