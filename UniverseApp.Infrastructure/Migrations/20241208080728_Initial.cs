using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniverseApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Movie Identifier"),
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Movie Title"),
                    EpisodeId = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false, comment: "Movie Episode Identifier"),
                    Description = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false, comment: "Movie Description"),
                    Director = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Movie Director"),
                    Producer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Movie Producer"),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Movie Release Date"),
                    Url = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Movie Image Url"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Whether the Entity has been deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                },
                comment: "Movie Entity");

            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Movie Identifier"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Planet Name"),
                    RotationPeriod = table.Column<int>(type: "int", maxLength: 7, nullable: true, comment: "Rotation Period of Planet"),
                    OrbitalPeriod = table.Column<int>(type: "int", maxLength: 7, nullable: true, comment: "Orbital Period of Planet"),
                    Diameter = table.Column<int>(type: "int", maxLength: 7, nullable: true, comment: "Diameter of Planet"),
                    Climate = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true, comment: "Climate of Planet"),
                    Gravity = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true, comment: "Gravity of Planet"),
                    Terrain = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true, comment: "Terrain of Planet"),
                    SurfaceWater = table.Column<decimal>(type: "decimal(5,2)", maxLength: 7, nullable: true, comment: "Surface Water of Planet"),
                    Population = table.Column<int>(type: "int", maxLength: 15, nullable: true, comment: "Population of Planet"),
                    Url = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Planet Url"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Whether the Entity has been deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                },
                comment: "Planet Entity");

            migrationBuilder.CreateTable(
                name: "Starships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Vehicle Identifier"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Vehicle Name"),
                    Model = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true, comment: "Vehicle Model"),
                    Manufacturer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Vehicle Manufacturer"),
                    CostInCredits = table.Column<int>(type: "int", maxLength: 15, nullable: true, comment: "Vehicle Cost In Credits"),
                    Length = table.Column<double>(type: "float", maxLength: 7, nullable: true, comment: "Vehicle Length"),
                    MaxAtmospheringSpeed = table.Column<int>(type: "int", maxLength: 4, nullable: true, comment: "Vehicle Max Atmosphering Speed"),
                    Crew = table.Column<int>(type: "int", maxLength: 10, nullable: true, comment: "Vehicle Crew"),
                    Passengers = table.Column<int>(type: "int", maxLength: 10, nullable: true, comment: "Vehicle Passengers"),
                    CargoCapacity = table.Column<int>(type: "int", maxLength: 15, nullable: true, comment: "Vehicle Cargo Capacity"),
                    Consumables = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Vehicle Consumables"),
                    Class = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true, comment: "Vehicle Class"),
                    Url = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Vehicle URL"),
                    HyperdriveRating = table.Column<double>(type: "float", maxLength: 3, nullable: true, comment: "Starship Hyperdrive Rating"),
                    MGLT = table.Column<int>(type: "int", maxLength: 3, nullable: true, comment: "Starship MGLT"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Whether the Entity has been deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Starships", x => x.Id);
                },
                comment: "Starship Entity");

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Vehicle Identifier"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Vehicle Name"),
                    Model = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true, comment: "Vehicle Model"),
                    Manufacturer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Vehicle Manufacturer"),
                    CostInCredits = table.Column<int>(type: "int", maxLength: 15, nullable: true, comment: "Vehicle Cost In Credits"),
                    Length = table.Column<double>(type: "float", maxLength: 7, nullable: true, comment: "Vehicle Length"),
                    MaxAtmospheringSpeed = table.Column<int>(type: "int", maxLength: 4, nullable: true, comment: "Vehicle Max Atmosphering Speed"),
                    Crew = table.Column<int>(type: "int", maxLength: 10, nullable: true, comment: "Vehicle Crew"),
                    Passengers = table.Column<int>(type: "int", maxLength: 10, nullable: true, comment: "Vehicle Passengers"),
                    CargoCapacity = table.Column<int>(type: "int", maxLength: 15, nullable: true, comment: "Vehicle Cargo Capacity"),
                    Consumables = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Vehicle Consumables"),
                    Class = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true, comment: "Vehicle Class"),
                    Url = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Vehicle URL"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Whether the Entity has been deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                },
                comment: "Vehicle Entity");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Character Identifier"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Character Name"),
                    Height = table.Column<int>(type: "int", nullable: true, comment: "Character Height"),
                    Mass = table.Column<int>(type: "int", nullable: true, comment: "Character Mass"),
                    HairColor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Character Hair Color"),
                    SkinColor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Character Skin Color"),
                    EyeColor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Character Eye Color"),
                    BirthYear = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, comment: "Character Birth Year"),
                    Gender = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true, comment: "Character Gender"),
                    PlanetId = table.Column<int>(type: "int", nullable: true, comment: "Character Home Planet"),
                    Url = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Character Url"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Whether the Entity has been deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id");
                },
                comment: "Character Entity");

            migrationBuilder.CreateTable(
                name: "MoviePlanet",
                columns: table => new
                {
                    MoviesId = table.Column<int>(type: "int", nullable: false),
                    PlanetsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviePlanet", x => new { x.MoviesId, x.PlanetsId });
                    table.ForeignKey(
                        name: "FK_MoviePlanet_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviePlanet_Planets_PlanetsId",
                        column: x => x.PlanetsId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Specie Identifier"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Specie Name"),
                    Classification = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Specie Classification"),
                    Designation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Specie Designation"),
                    AverageHeight = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, comment: "Specie Average Height"),
                    SkinColors = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Specie SkinColor"),
                    HairColors = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Specie HairColor"),
                    EyeColors = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Specie EyeColor"),
                    AverageLifespan = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true, comment: "Specie Average Lifespan"),
                    PlanetId = table.Column<int>(type: "int", maxLength: 50, nullable: true, comment: "Specie Homeworld"),
                    Language = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "Specie Language"),
                    Url = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Specie Url"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Whether the Entity has been deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Species_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id");
                },
                comment: "Specie Entity");

            migrationBuilder.CreateTable(
                name: "MovieStarship",
                columns: table => new
                {
                    MoviesId = table.Column<int>(type: "int", nullable: false),
                    StarshipsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieStarship", x => new { x.MoviesId, x.StarshipsId });
                    table.ForeignKey(
                        name: "FK_MovieStarship_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieStarship_Starships_StarshipsId",
                        column: x => x.StarshipsId,
                        principalTable: "Starships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieVehicle",
                columns: table => new
                {
                    MoviesId = table.Column<int>(type: "int", nullable: false),
                    VehiclesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieVehicle", x => new { x.MoviesId, x.VehiclesId });
                    table.ForeignKey(
                        name: "FK_MovieVehicle_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieVehicle_Vehicles_VehiclesId",
                        column: x => x.VehiclesId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterMovie",
                columns: table => new
                {
                    CharactersId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterMovie", x => new { x.CharactersId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_CharacterMovie_Characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterMovie_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
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
                name: "MovieSpecie",
                columns: table => new
                {
                    MoviesId = table.Column<int>(type: "int", nullable: false),
                    SpeciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieSpecie", x => new { x.MoviesId, x.SpeciesId });
                    table.ForeignKey(
                        name: "FK_MovieSpecie_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieSpecie_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "18990560-1cca-49b8-b4db-5adb987559c3", 0, "b4b721ba-3706-462f-8213-643a72b03eaf", "UniverseUser", "user@mail.com", false, "First", "User", false, null, "USER@MAIL.COM", "USER@MAIL.COM", "AQAAAAIAAYagAAAAEDzd0XgM3qDkIJlhjuVQTMkhsqhBEDIToxpTrBbRIQ1Ddm3+c3FV/Kj+TyutAUqZPw==", null, false, "45d68651-1b79-402f-b6ec-aa6d321109e3", false, "user@mail.com" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "EpisodeId", "ImageUrl", "IsDeleted", "Producer", "ReleaseDate", "Title", "Url" },
                values: new object[,]
                {
                    { 1, "It is a period of civil war.\r\nRebel spaceships, striking\r\nfrom a hidden base, have won\r\ntheir first victory against\r\nthe evil Galactic Empire.\r\n\r\nDuring the battle, Rebel\r\nspies managed to steal secret\r\nplans to the Empire's\r\nultimate weapon, the DEATH\r\nSTAR, an armored space\r\nstation with enough power\r\nto destroy an entire planet.\r\n\r\nPursued by the Empire's\r\nsinister agents, Princess\r\nLeia races home aboard her\r\nstarship, custodian of the\r\nstolen plans that can save her\r\npeople and restore\r\nfreedom to the galaxy....", "George Lucas", "4", "", false, "Gary Kurtz, Rick McCallum", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "A New Hope", "https://swapi.dev/api/films/1/" },
                    { 2, "It is a dark time for the\r\nRebellion. Although the Death\r\nStar has been destroyed,\r\nImperial troops have driven the\r\nRebel forces from their hidden\r\nbase and pursued them across\r\nthe galaxy.\r\n\r\nEvading the dreaded Imperial\r\nStarfleet, a group of freedom\r\nfighters led by Luke Skywalker\r\nhas established a new secret\r\nbase on the remote ice world\r\nof Hoth.\r\n\r\nThe evil lord Darth Vader,\r\nobsessed with finding young\r\nSkywalker, has dispatched\r\nthousands of remote probes into\r\nthe far reaches of space....", "Irvin Kershner", "5", "", false, "Gary Kurtz, Rick McCallum", new DateTime(1980, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Empire Strikes Back", "https://swapi.dev/api/films/2/" },
                    { 3, "Luke Skywalker has returned to\r\nhis home planet of Tatooine in\r\nan attempt to rescue his\r\nfriend Han Solo from the\r\nclutches of the vile gangster\r\nJabba the Hutt.\r\n\r\nLittle does Luke know that the\r\nGALACTIC EMPIRE has secretly\r\nbegun construction on a new\r\narmored space station even\r\nmore powerful than the first\r\ndreaded Death Star.\r\n\r\nWhen completed, this ultimate\r\nweapon will spell certain doom\r\nfor the small band of rebels\r\nstruggling to restore freedom\r\nto the galaxy...", "Richard Marquand", "6", "", false, "Howard G. Kazanjian, George Lucas, Rick McCallum", new DateTime(1983, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Return of the Jedi", "https://swapi.dev/api/films/3/" },
                    { 4, "Turmoil has engulfed the\r\nGalactic Republic. The taxation\r\nof trade routes to outlying star\r\nsystems is in dispute.\r\n\r\nHoping to resolve the matter\r\nwith a blockade of deadly\r\nbattleships, the greedy Trade\r\nFederation has stopped all\r\nshipping to the small planet\r\nof Naboo.\r\n\r\nWhile the Congress of the\r\nRepublic endlessly debates\r\nthis alarming chain of events,\r\nthe Supreme Chancellor has\r\nsecretly dispatched two Jedi\r\nKnights, the guardians of\r\npeace and justice in the\r\ngalaxy, to settle the conflict....", "George Lucas", "1", "", false, "Rick McCallum", new DateTime(1999, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Phantom Menace", "https://swapi.dev/api/films/4/" },
                    { 5, "There is unrest in the Galactic\r\nSenate. Several thousand solar\r\nsystems have declared their\r\nintentions to leave the Republic.\r\n\r\nThis separatist movement,\r\nunder the leadership of the\r\nmysterious Count Dooku, has\r\nmade it difficult for the limited\r\nnumber of Jedi Knights to maintain \r\npeace and order in the galaxy.\r\n\r\nSenator Amidala, the former\r\nQueen of Naboo, is returning\r\nto the Galactic Senate to vote\r\non the critical issue of creating\r\nan ARMY OF THE REPUBLIC\r\nto assist the overwhelmed\r\nJedi....", "George Lucas", "2", "", false, "Rick McCallum", new DateTime(2002, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Attack of the Clones", "https://swapi.dev/api/films/5/" },
                    { 6, "War! The Republic is crumbling\r\nunder attacks by the ruthless\r\nSith Lord, Count Dooku.\r\nThere are heroes on both sides.\r\nEvil is everywhere.\r\n\r\nIn a stunning move, the\r\nfiendish droid leader, General\r\nGrievous, has swept into the\r\nRepublic capital and kidnapped\r\nChancellor Palpatine, leader of\r\nthe Galactic Senate.\r\n\r\nAs the Separatist Droid Army\r\nattempts to flee the besieged\r\ncapital with their valuable\r\nhostage, two Jedi Knights lead a\r\ndesperate mission to rescue the\r\ncaptive Chancellor....", "George Lucas", "3", "", false, "Rick McCallum", new DateTime(2005, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Revenge of the Sith", "https://swapi.dev/api/films/6/" }
                });

            migrationBuilder.InsertData(
                table: "Planets",
                columns: new[] { "Id", "Climate", "Diameter", "Gravity", "IsDeleted", "Name", "OrbitalPeriod", "Population", "RotationPeriod", "SurfaceWater", "Terrain", "Url" },
                values: new object[,]
                {
                    { 1, "[\"arid\"]", 10465, "1 standard", false, "Tatooine", 304, 200000, 23, 1m, "[\"desert\"]", "https://swapi.dev/api/planets/1/" },
                    { 2, "[\"temperate\"]", 12500, "1 standard", false, "Alderaan", 364, 2000000000, 24, 40m, "[\"grasslands\",\"mountains\"]", "https://swapi.dev/api/planets/2/" },
                    { 3, "[\"temperate\",\"tropical\"]", 10200, "1 standard", false, "Yavin IV", 4818, 1000, 24, 8m, "[\"jungle\",\"rainforests\"]", "https://swapi.dev/api/planets/3/" },
                    { 4, "[\"frozen\"]", 7200, "1.1 standard", false, "Hoth", 549, null, 23, 100m, "[\"tundra\",\"ice caves\",\"mountain ranges\"]", "https://swapi.dev/api/planets/4/" },
                    { 5, "[\"murky\"]", 8900, "N/A", false, "Dagobah", 341, null, 23, 8m, "[\"swamp\",\"jungles\"]", "https://swapi.dev/api/planets/5/" },
                    { 6, "[\"temperate\"]", 118000, "1.5 (surface), 1 standard (Cloud City)", false, "Bespin", 5110, 6000000, 12, 0m, "[\"gas giant\"]", "https://swapi.dev/api/planets/6/" },
                    { 7, "[\"temperate\"]", 4900, "0.85 standard", false, "Endor", 402, 30000000, 18, 8m, "[\"forests\",\"mountains\",\"lakes\"]", "https://swapi.dev/api/planets/7/" },
                    { 8, "[\"temperate\"]", 12120, "1 standard", false, "Naboo", 312, null, 26, 12m, "[\"grassy hills\",\"swamps\",\"forests\",\"mountains\"]", "https://swapi.dev/api/planets/8/" },
                    { 9, "[\"temperate\"]", 12240, "1 standard", false, "Coruscant", 368, null, 24, null, "[\"cityscape\",\"mountains\"]", "https://swapi.dev/api/planets/9/" },
                    { 10, "[\"temperate\"]", 19720, "1 standard", false, "Kamino", 463, 1000000000, 27, 100m, "[\"ocean\"]", "https://swapi.dev/api/planets/10/" },
                    { 11, "[\"temperate\",\"arid\"]", 11370, "0.9 standard", false, "Geonosis", 256, null, 30, 5m, "[\"rock\",\"desert\",\"mountain\",\"barren\"]", "https://swapi.dev/api/planets/11/" },
                    { 12, "[\"temperate\",\"arid\",\"windy\"]", 12900, "1 standard", false, "Utapau", 351, 95000000, 27, null, "[\"scrublands\",\"savanna\",\"canyons\",\"sinkholes\"]", "https://swapi.dev/api/planets/12/" },
                    { 13, "[\"hot\"]", 4200, "1 standard", false, "Mustafar", 412, 20000, 36, 0m, "[\"volcanoes\",\"lava rivers\",\"mountains\",\"caves\"]", "https://swapi.dev/api/planets/13/" },
                    { 14, "[\"tropical\"]", 12765, "1 standard", false, "Kashyyyk", 381, 45000000, 26, 60m, "[\"jungle\",\"forests\",\"lakes\",\"rivers\"]", "https://swapi.dev/api/planets/14/" },
                    { 15, "[\"artificial temperate \"]", 0, "0.56 standard", false, "Polis Massa", 590, 1000000, 24, 0m, "[\"airless asteroid\"]", "https://swapi.dev/api/planets/15/" },
                    { 16, "[\"frigid\"]", 10088, "1 standard", false, "Mygeeto", 167, 19000000, 12, null, "[\"glaciers\",\"mountains\",\"ice canyons\"]", "https://swapi.dev/api/planets/16/" },
                    { 17, "[\"hot\",\"humid\"]", 9100, "0.75 standard", false, "Felucia", 231, 8500000, 34, null, "[\"fungus forests\"]", "https://swapi.dev/api/planets/17/" },
                    { 18, "[\"temperate\",\"moist\"]", 0, "1 standard", false, "Cato Neimoidia", 278, 10000000, 25, null, "[\"mountains\",\"fields\",\"forests\",\"rock arches\"]", "https://swapi.dev/api/planets/18/" },
                    { 19, "[\"hot\"]", 14920, "unknown", false, "Saleucami", 392, 1400000000, 26, null, "[\"caves\",\"desert\",\"mountains\",\"volcanoes\"]", "https://swapi.dev/api/planets/19/" },
                    { 20, "[\"temperate\"]", 0, "1 standard", false, "Stewjon", null, null, null, null, "[\"grass\"]", "https://swapi.dev/api/planets/20/" },
                    { 21, "[\"polluted\"]", 13490, "1 standard", false, "Eriadu", 360, null, 24, null, "[\"cityscape\"]", "https://swapi.dev/api/planets/21/" },
                    { 22, "[\"temperate\"]", 11000, "1 standard", false, "Corellia", 329, null, 25, 70m, "[\"plains\",\"urban\",\"hills\",\"forests\"]", "https://swapi.dev/api/planets/22/" },
                    { 23, "[\"hot\"]", 7549, "1 standard", false, "Rodia", 305, 1300000000, 29, 60m, "[\"jungles\",\"oceans\",\"urban\",\"swamps\"]", "https://swapi.dev/api/planets/23/" },
                    { 24, "[\"temperate\"]", 12150, "1 standard", false, "Nal Hutta", 413, null, 87, null, "[\"urban\",\"oceans\",\"swamps\",\"bogs\"]", "https://swapi.dev/api/planets/24/" },
                    { 25, "[\"temperate\"]", 9830, "1 standard", false, "Dantooine", 378, 1000, 25, null, "[\"oceans\",\"savannas\",\"mountains\",\"grasslands\"]", "https://swapi.dev/api/planets/25/" },
                    { 26, "[\"temperate\"]", 6400, "unknown", false, "Bestine IV", 680, 62000000, 26, 98m, "[\"rocky islands\",\"oceans\"]", "https://swapi.dev/api/planets/26/" },
                    { 27, "[\"temperate\"]", 14050, "1 standard", false, "Ord Mantell", 334, null, 26, 10m, "[\"plains\",\"seas\",\"mesas\"]", "https://swapi.dev/api/planets/27/" },
                    { 28, "[\"unknown\"]", 0, "unknown", false, "unknown", 0, null, 0, null, "[\"unknown\"]", "https://swapi.dev/api/planets/28/" },
                    { 29, "[\"arid\"]", 0, "0.62 standard", false, "Trandosha", 371, 42000000, 25, null, "[\"mountains\",\"seas\",\"grasslands\",\"deserts\"]", "https://swapi.dev/api/planets/29/" },
                    { 30, "[\"arid\"]", 0, "1 standard", false, "Socorro", 326, 300000000, 20, null, "[\"deserts\",\"mountains\"]", "https://swapi.dev/api/planets/30/" },
                    { 31, "[\"temperate\"]", 11030, "1", false, "Mon Cala", 398, null, 21, 100m, "[\"oceans\",\"reefs\",\"islands\"]", "https://swapi.dev/api/planets/31/" },
                    { 32, "[\"temperate\"]", 13500, "1", false, "Chandrila", 368, 1200000000, 20, 40m, "[\"plains\",\"forests\"]", "https://swapi.dev/api/planets/32/" },
                    { 33, "[\"superheated\"]", 12780, "1", false, "Sullust", 263, null, 20, 5m, "[\"mountains\",\"volcanoes\",\"rocky deserts\"]", "https://swapi.dev/api/planets/33/" },
                    { 34, "[\"temperate\"]", 7900, "1", false, "Toydaria", 184, 11000000, 21, null, "[\"swamps\",\"lakes\"]", "https://swapi.dev/api/planets/34/" },
                    { 35, "[\"arid\",\"temperate\",\"tropical\"]", 18880, "1.56", false, "Malastare", 201, 2000000000, 26, null, "[\"swamps\",\"deserts\",\"jungles\",\"mountains\"]", "https://swapi.dev/api/planets/35/" },
                    { 36, "[\"temperate\"]", 10480, "0.9", false, "Dathomir", 491, 5200, 24, null, "[\"forests\",\"deserts\",\"savannas\"]", "https://swapi.dev/api/planets/36/" },
                    { 37, "[\"temperate\",\"arid\",\"subartic\"]", 10600, "1", false, "Ryloth", 305, 1500000000, 30, 5m, "[\"mountains\",\"valleys\",\"deserts\",\"tundra\"]", "https://swapi.dev/api/planets/37/" },
                    { 38, "[\"unknown\"]", null, "unknown", false, "Aleen Minor", null, null, null, null, "[\"unknown\"]", "https://swapi.dev/api/planets/38/" },
                    { 39, "[\"temperate\",\"artic\"]", 14900, "1", false, "Vulpter", 391, 421000000, 22, null, "[\"urban\",\"barren\"]", "https://swapi.dev/api/planets/39/" },
                    { 40, "[\"unknown\"]", null, "unknown", false, "Troiken", null, null, null, null, "[\"desert\",\"tundra\",\"rainforests\",\"mountains\"]", "https://swapi.dev/api/planets/40/" },
                    { 41, "[\"unknown\"]", 12190, "unknown", false, "Tund", 1770, 0, 48, null, "[\"barren\",\"ash\"]", "https://swapi.dev/api/planets/41/" },
                    { 42, "[\"temperate\"]", 10120, "0.98", false, "Haruun Kal", 383, 705300, 25, null, "[\"toxic cloudsea\",\"plateaus\",\"volcanoes\"]", "https://swapi.dev/api/planets/42/" },
                    { 43, "[\"temperate\"]", null, "1", false, "Cerea", 386, 450000000, 27, 20m, "[\"verdant\"]", "https://swapi.dev/api/planets/43/" },
                    { 44, "[\"tropical\",\"temperate\"]", 15600, "1", false, "Glee Anselm", 206, 500000000, 33, 80m, "[\"lakes\",\"islands\",\"swamps\",\"seas\"]", "https://swapi.dev/api/planets/44/" },
                    { 45, "[\"unknown\"]", null, "unknown", false, "Iridonia", 413, null, 29, null, "[\"rocky canyons\",\"acid pools\"]", "https://swapi.dev/api/planets/45/" },
                    { 46, "[\"unknown\"]", null, "unknown", false, "Tholoth", null, null, null, null, "[\"unknown\"]", "https://swapi.dev/api/planets/46/" },
                    { 47, "[\"arid\",\"rocky\",\"windy\"]", null, "1", false, "Iktotch", 481, null, 22, null, "[\"rocky\"]", "https://swapi.dev/api/planets/47/" },
                    { 48, "[\"unknown\"]", null, "unknown", false, "Quermia", null, null, null, null, "[\"unknown\"]", "https://swapi.dev/api/planets/48/" },
                    { 49, "[\"temperate\"]", 13400, "1", false, "Dorin", 409, null, 22, null, "[\"unknown\"]", "https://swapi.dev/api/planets/49/" },
                    { 50, "[\"temperate\"]", null, "1", false, "Champala", 318, null, 27, null, "[\"oceans\",\"rainforests\",\"plateaus\"]", "https://swapi.dev/api/planets/50/" },
                    { 51, "[\"unknown\"]", null, "unknown", false, "Mirial", null, null, null, null, "[\"deserts\"]", "https://swapi.dev/api/planets/51/" },
                    { 52, "[\"unknown\"]", null, "unknown", false, "Serenno", null, null, null, null, "[\"rainforests\",\"rivers\",\"mountains\"]", "https://swapi.dev/api/planets/52/" },
                    { 53, "[\"unknown\"]", null, "unknown", false, "Concord Dawn", null, null, null, null, "[\"jungles\",\"forests\",\"deserts\"]", "https://swapi.dev/api/planets/53/" },
                    { 54, "[\"unknown\"]", null, "unknown", false, "Zolan", null, null, null, null, "[\"unknown\"]", "https://swapi.dev/api/planets/54/" },
                    { 55, "[\"frigid\"]", null, "unknown", false, "Ojom", null, 500000000, null, 100m, "[\"oceans\",\"glaciers\"]", "https://swapi.dev/api/planets/55/" },
                    { 56, "[\"temperate\"]", null, "1", false, "Skako", 384, null, 27, null, "[\"urban\",\"vines\"]", "https://swapi.dev/api/planets/56/" },
                    { 57, "[\"temperate\"]", 13800, "1", false, "Muunilinst", 412, null, 28, 25m, "[\"plains\",\"forests\",\"hills\",\"mountains\"]", "https://swapi.dev/api/planets/57/" },
                    { 58, "[\"temperate\"]", null, "1", false, "Shili", null, null, null, null, "[\"cities\",\"savannahs\",\"seas\",\"plains\"]", "https://swapi.dev/api/planets/58/" },
                    { 59, "[\"arid\",\"temperate\",\"tropical\"]", 13850, "1", false, "Kalee", 378, null, 23, null, "[\"rainforests\",\"cliffs\",\"canyons\",\"seas\"]", "https://swapi.dev/api/planets/59/" },
                    { 60, "[\"unknown\"]", null, "unknown", false, "Umbara", null, null, null, null, "[\"unknown\"]", "https://swapi.dev/api/planets/60/" }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "AverageHeight", "AverageLifespan", "Classification", "Designation", "EyeColors", "HairColors", "IsDeleted", "Language", "Name", "PlanetId", "SkinColors", "Url" },
                values: new object[] { 2, "n/a", "indefinite", "artificial", "sentient", "n/a", "n/a", false, "n/a", "Droid", null, "n/a", "https://swapi.dev/api/species/2/" });

            migrationBuilder.InsertData(
                table: "Starships",
                columns: new[] { "Id", "CargoCapacity", "Class", "Consumables", "CostInCredits", "Crew", "HyperdriveRating", "IsDeleted", "Length", "MGLT", "Manufacturer", "MaxAtmospheringSpeed", "Model", "Name", "Passengers", "Url" },
                values: new object[,]
                {
                    { 2, 3000000, null, "1 year", 3500000, null, null, false, 150.0, 60, "Corellian Engineering Corporation", 950, "CR90 corvette", "CR90 corvette", 600, "https://swapi.dev/api/starships/2/" },
                    { 3, 36000000, null, "2 years", 150000000, null, null, false, null, 60, "Kuat Drive Yards", 975, "Imperial I-class Star Destroyer", "Star Destroyer", null, "https://swapi.dev/api/starships/3/" },
                    { 5, 180000, null, "1 month", 240000, 5, null, false, 38.0, 70, "Sienar Fleet Systems, Cyngus Spaceworks", 1000, "Sentinel-class landing craft", "Sentinel-class landing craft", 75, "https://swapi.dev/api/starships/5/" },
                    { 9, null, null, "3 years", null, null, null, false, 120000.0, 10, "Imperial Department of Military Research, Sienar Fleet Systems", null, "DS-1 Orbital Battle Station", "Death Star", null, "https://swapi.dev/api/starships/9/" },
                    { 10, 100000, null, "2 months", 100000, 4, null, false, null, 75, "Corellian Engineering Corporation", 1050, "YT-1300 light freighter", "Millennium Falcon", 6, "https://swapi.dev/api/starships/10/" },
                    { 11, 110, null, "1 week", 134999, 2, null, false, 14.0, 80, "Koensayr Manufacturing", null, "BTL Y-wing", "Y-wing", 0, "https://swapi.dev/api/starships/11/" },
                    { 12, 110, null, "1 week", 149999, 1, null, false, null, 100, "Incom Corporation", 1050, "T-65 X-wing", "X-wing", 0, "https://swapi.dev/api/starships/12/" },
                    { 13, 150, null, "5 days", null, 1, null, false, null, 105, "Sienar Fleet Systems", 1200, "Twin Ion Engine Advanced x1", "TIE Advanced x1", 0, "https://swapi.dev/api/starships/13/" },
                    { 15, 250000000, null, "6 years", 1143350000, null, null, false, 19000.0, 40, "Kuat Drive Yards, Fondor Shipyards", null, "Executor-class star dreadnought", "Executor", 38000, "https://swapi.dev/api/starships/15/" },
                    { 17, 19000000, null, "6 months", null, 6, null, false, 90.0, 20, "Gallofree Yards, Inc.", 650, "GR-75 medium transport", "Rebel transport", 90, "https://swapi.dev/api/starships/17/" },
                    { 21, 70000, null, "1 month", null, 1, null, false, null, 70, "Kuat Systems Engineering", 1000, "Firespray-31-class patrol and attack", "Slave 1", 6, "https://swapi.dev/api/starships/21/" },
                    { 22, 80000, null, "2 months", 240000, 6, null, false, 20.0, 50, "Sienar Fleet Systems", 850, "Lambda-class T-4a shuttle", "Imperial shuttle", 20, "https://swapi.dev/api/starships/22/" },
                    { 23, 6000000, null, "2 years", 8500000, 854, null, false, 300.0, 40, "Kuat Drive Yards", 800, "EF76 Nebulon-B escort frigate", "EF76 Nebulon-B escort frigate", 75, "https://swapi.dev/api/starships/23/" },
                    { 27, null, null, "2 years", 104000000, 5400, null, false, 1200.0, 60, "Mon Calamari shipyards", null, "MC80 Liberty type Star Cruiser", "Calamari Cruiser", 1200, "https://swapi.dev/api/starships/27/" },
                    { 28, 40, null, "1 week", 175000, 1, null, false, null, 120, "Alliance Underground Engineering, Incom Corporation", 1300, "RZ-1 A-wing Interceptor", "A-wing", 0, "https://swapi.dev/api/starships/28/" },
                    { 29, 45, null, "1 week", 220000, 1, null, false, null, 91, "Slayn & Korpil", 950, "A/SF-01 B-wing starfighter", "B-wing", 0, "https://swapi.dev/api/starships/29/" },
                    { 31, null, null, "unknown", null, 9, null, false, 115.0, null, "Corellian Engineering Corporation", 900, "Consular-class cruiser", "Republic Cruiser", 16, "https://swapi.dev/api/starships/31/" },
                    { 32, null, null, "500 days", null, 175, null, false, 3170.0, null, "Hoersch-Kessel Drive, Inc.", null, "Lucrehulk-class Droid Control Ship", "Droid control ship", 139000, "https://swapi.dev/api/starships/32/" },
                    { 39, 65, null, "7 days", 200000, 1, null, false, 11.0, null, "Theed Palace Space Vessel Engineering Corps", 1100, "N-1 starfighter", "Naboo fighter", 0, "https://swapi.dev/api/starships/39/" },
                    { 40, null, null, "unknown", null, 8, null, false, 76.0, null, "Theed Palace Space Vessel Engineering Corps, Nubia Star Drives", 920, "J-type 327 Nubian royal starship", "Naboo Royal Starship", null, "https://swapi.dev/api/starships/40/" },
                    { 41, 2500000, null, "30 days", 55000000, 1, null, false, null, null, "Republic Sienar Systems", 1180, "Star Courier", "Scimitar", 6, "https://swapi.dev/api/starships/41/" },
                    { 43, null, null, "1 year", 2000000, 5, null, false, 39.0, null, "Theed Palace Space Vessel Engineering Corps, Nubia Star Drives", 2000, "J-type diplomatic barge", "J-type diplomatic barge", 10, "https://swapi.dev/api/starships/43/" },
                    { 47, null, null, "unknown", null, null, null, false, 390.0, null, "Botajef Shipyards", null, "Botajef AA-9 Freighter-Liner", "AA-9 Coruscant freighter", 30000, "https://swapi.dev/api/starships/47/" },
                    { 48, 60, null, "7 days", 180000, 1, null, false, 8.0, null, "Kuat Systems Engineering", 1150, "Delta-7 Aethersprite-class interceptor", "Jedi starfighter", 0, "https://swapi.dev/api/starships/48/" },
                    { 49, null, null, "unknown", null, 4, null, false, null, null, "Theed Palace Space Vessel Engineering Corps", 8000, "H-type Nubian yacht", "H-type Nubian yacht", null, "https://swapi.dev/api/starships/49/" },
                    { 52, 11250000, null, "2 years", null, 700, null, false, 752.0, null, "Rothana Heavy Engineering", null, "Acclamator I-class assault ship", "Republic Assault ship", 16000, "https://swapi.dev/api/starships/52/" },
                    { 58, 240, null, "7 days", 35700, 3, null, false, null, null, "Huppla Pasa Tisc Shipwrights Collective", 1600, "Punworcca 116-class interstellar sloop", "Solar Sailer", 11, "https://swapi.dev/api/starships/58/" },
                    { 59, 50000000, null, "4 years", 125000000, 600, null, false, 1088.0, null, "Rendili StarDrive, Free Dac Volunteers Engineering corps.", 1050, "Providence-class carrier/destroyer", "Trade Federation cruiser", 48247, "https://swapi.dev/api/starships/59/" },
                    { 61, 50000, null, "56 days", 1000000, 5, null, false, null, null, "Cygnus Spaceworks", 2000, "Theta-class T-2c shuttle", "Theta-class T-2c shuttle", 16, "https://swapi.dev/api/starships/61/" },
                    { 63, 20000000, null, "2 years", 59000000, 7400, null, false, 1137.0, null, "Kuat Drive Yards, Allanteen Six shipyards", 975, "Senator-class Star Destroyer", "Republic attack cruiser", 2000, "https://swapi.dev/api/starships/63/" },
                    { 64, null, null, "unknown", null, 3, null, false, null, null, "Theed Palace Space Vessel Engineering Corps/Nubia Star Drives, Incorporated", 1050, "J-type star skiff", "Naboo star skiff", 3, "https://swapi.dev/api/starships/64/" },
                    { 65, 60, null, "2 days", 320000, 1, null, false, null, null, "Kuat Systems Engineering", 1500, "Eta-2 Actis-class light interceptor", "Jedi Interceptor", 0, "https://swapi.dev/api/starships/65/" },
                    { 66, 110, null, "5 days", 155000, 3, null, false, null, 100, "Incom Corporation, Subpro Corporation", 1000, "Aggressive Reconnaissance-170 starfighte", "arc-170", 0, "https://swapi.dev/api/starships/66/" },
                    { 68, 40000000, null, "2 years", 57000000, 200, null, false, 825.0, null, "Hoersch-Kessel Drive, Inc, Gwori Revolutionary Industries", null, "Munificent-class star frigate", "Banking clan frigte", null, "https://swapi.dev/api/starships/68/" },
                    { 74, 140, null, "7 days", 168000, 1, 6.0, false, null, null, "Feethan Ottraw Scalable Assemblies", 1100, "Belbullab-22 starfighter", "Belbullab-22 starfighter", 0, "https://swapi.dev/api/starships/74/" },
                    { 75, 60, null, "15 hours", 102500, 1, null, false, null, null, "Kuat Systems Engineering", 1050, "Alpha-3 Nimbus-class V-wing starfighter", "V-wing", 0, "https://swapi.dev/api/starships/75/" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CargoCapacity", "Class", "Consumables", "CostInCredits", "Crew", "IsDeleted", "Length", "Manufacturer", "MaxAtmospheringSpeed", "Model", "Name", "Passengers", "Url" },
                values: new object[,]
                {
                    { 4, 50000, "wheeled", "2 months", 150000, 46, false, 36.799999999999997, "Corellia Mining Corporation", 30, "Digger Crawler", "Sand Crawler", 30, "https://swapi.dev/api/vehicles/4/" },
                    { 6, 50, "repulsorcraft", "0", 14500, 1, false, 10.4, "Incom Corporation", 1200, "T-16 skyhopper", "T-16 skyhopper", 1, "https://swapi.dev/api/vehicles/6/" },
                    { 7, 5, "repulsorcraft", "unknown", 10550, 1, false, 3.3999999999999999, "SoroSuub Corporation", 250, "X-34 landspeeder", "X-34 landspeeder", 1, "https://swapi.dev/api/vehicles/7/" },
                    { 8, 65, "starfighter", "2 days", null, 1, false, 6.4000000000000004, "Sienar Fleet Systems", 1200, "Twin Ion Engine/Ln Starfighter", "TIE/LN starfighter", 0, "https://swapi.dev/api/vehicles/8/" },
                    { 14, 10, "airspeeder", "none", null, 2, false, 4.5, "Incom corporation", 650, "t-47 airspeeder", "Snowspeeder", 0, "https://swapi.dev/api/vehicles/14/" },
                    { 16, null, "space/planetary bomber", "2 days", null, 1, false, 7.7999999999999998, "Sienar Fleet Systems", 850, "TIE/sa bomber", "TIE bomber", 0, "https://swapi.dev/api/vehicles/16/" },
                    { 18, 1000, "assault walker", "unknown", null, 5, false, 20.0, "Kuat Drive Yards, Imperial Department of Military Research", 60, "All Terrain Armored Transport", "AT-AT", 40, "https://swapi.dev/api/vehicles/18/" },
                    { 19, 200, "walker", "none", null, 2, false, 2.0, "Kuat Drive Yards, Imperial Department of Military Research", 90, "All Terrain Scout Transport", "AT-ST", 0, "https://swapi.dev/api/vehicles/19/" },
                    { 20, 10, "repulsorcraft", "1 day", 75000, 2, false, 7.0, "Bespin Motors", 1500, "Storm IV Twin-Pod", "Storm IV Twin-Pod cloud car", 0, "https://swapi.dev/api/vehicles/20/" },
                    { 24, 2000000, "sail barge", "Live food tanks", 285000, 26, false, 30.0, "Ubrikkian Industries Custom Vehicle Division", 100, "Modified Luxury Sail Barge", "Sail barge", 500, "https://swapi.dev/api/vehicles/24/" },
                    { 25, 135000, "repulsorcraft cargo skiff", "1 day", 8000, 5, false, 9.5, "Ubrikkian Industries", 250, "Bantha-II", "Bantha-II cargo skiff", 16, "https://swapi.dev/api/vehicles/25/" },
                    { 26, 75, "starfighter", "2 days", null, 1, false, 9.5999999999999996, "Sienar Fleet Systems", 1250, "Twin Ion Engine Interceptor", "TIE/IN interceptor", 0, "https://swapi.dev/api/vehicles/26/" },
                    { 30, 4, "speeder", "1 day", 8000, 1, false, 3.0, "Aratech Repulsor Company", 360, "74-Z speeder bike", "Imperial Speeder Bike", 1, "https://swapi.dev/api/vehicles/30/" },
                    { 33, 0, "starfighter", "none", null, 0, false, 3.5, "Haor Chall Engineering, Baktoid Armor Workshop", 1200, "Vulture-class droid starfighter", "Vulture Droid", 0, "https://swapi.dev/api/vehicles/33/" },
                    { 34, 12000, "repulsorcraft", "unknown", 138000, 4, false, 31.0, "Baktoid Armor Workshop", 35, "Multi-Troop Transport", "Multi-Troop Transport", 112, "https://swapi.dev/api/vehicles/34/" },
                    { 35, null, "repulsorcraft", "unknown", null, 4, false, 9.75, "Baktoid Armor Workshop", 55, "Armoured Assault Tank", "Armored Assault Tank", 6, "https://swapi.dev/api/vehicles/35/" },
                    { 36, null, "repulsorcraft", "none", 2500, 1, false, 2.0, "Baktoid Armor Workshop", 400, "Single Trooper Aerial Platform", "Single Trooper Aerial Platform", 0, "https://swapi.dev/api/vehicles/36/" },
                    { 37, 1800000, "landing craft", "1 day", 200000, 140, false, 210.0, "Haor Chall Engineering", 587, "C-9979 landing craft", "C-9979 landing craft", 284, "https://swapi.dev/api/vehicles/37/" },
                    { 38, 1600, "submarine", "unknown", null, 1, false, 15.0, "Otoh Gunga Bongameken Cooperative", 85, "Tribubble bongo", "Tribubble bongo", 2, "https://swapi.dev/api/vehicles/38/" },
                    { 42, 2, "speeder", "unknown", 4000, 1, false, 1.5, "Razalon", 180, "FC-20 speeder bike", "Sith speeder", 0, "https://swapi.dev/api/vehicles/42/" },
                    { 44, 200, "repulsorcraft", "none", 5750, 1, false, 3.6800000000000002, "Mobquet Swoops and Speeders", 350, "Zephyr-G swoop bike", "Zephyr-G swoop bike", 1, "https://swapi.dev/api/vehicles/44/" },
                    { 45, 80, "airspeeder", "unknown", null, 1, false, 6.5999999999999996, "Desler Gizh Outworld Mobility Corporation", 800, "Koro-2 Exodrive airspeeder", "Koro-2 Exodrive airspeeder", 1, "https://swapi.dev/api/vehicles/45/" },
                    { 46, null, "airspeeder", "unknown", null, 1, false, 6.2300000000000004, "Narglatch AirTech prefabricated kit", 720, "XJ-6 airspeeder", "XJ-6 airspeeder", 1, "https://swapi.dev/api/vehicles/46/" },
                    { 50, 170, "gunship", "unknown", null, 6, false, 17.399999999999999, "Rothana Heavy Engineering", 620, "Low Altitude Assault Transport/infrantry", "LAAT/i", 30, "https://swapi.dev/api/vehicles/50/" },
                    { 51, 40000, "gunship", "unknown", null, 1, false, 28.82, "Rothana Heavy Engineering", 620, "Low Altitude Assault Transport/carrier", "LAAT/c", 0, "https://swapi.dev/api/vehicles/51/" },
                    { 53, 10000, "walker", "21 days", null, 6, false, 13.199999999999999, "Rothana Heavy Engineering, Kuat Drive Yards", 60, "All Terrain Tactical Enforcer", "AT-TE", 36, "https://swapi.dev/api/vehicles/53/" },
                    { 54, 500, "walker", "7 days", null, 25, false, 140.0, "Rothana Heavy Engineering", 35, "Self-Propelled Heavy Artillery", "SPHA", 30, "https://swapi.dev/api/vehicles/54/" },
                    { 55, null, "speeder", "unknown", 8000, 1, false, 2.0, "Huppla Pasa Tisc Shipwrights Collective", 634, "Flitknot speeder", "Flitknot speeder", 0, "https://swapi.dev/api/vehicles/55/" },
                    { 56, 1000, "transport", "7 days", null, 2, false, 20.0, "Haor Chall Engineering", 880, "Sheathipede-class transport shuttle", "Neimoidian shuttle", 6, "https://swapi.dev/api/vehicles/56/" },
                    { 57, null, "starfighter", "unknown", null, 1, false, 9.8000000000000007, "Huppla Pasa Tisc Shipwrights Collective", 20000, "Nantex-class territorial defense", "Geonosian starfighter", 0, "https://swapi.dev/api/vehicles/57/" },
                    { 60, 10, "wheeled walker", "none", 15000, 1, false, 3.5, "Z-Gomot Ternbuell Guppat Corporation", 330, "Tsmeu-6 personal wheel bike", "Tsmeu-6 personal wheel bike", 1, "https://swapi.dev/api/vehicles/60/" },
                    { 62, null, "fire suppression ship", "unknown", null, 2, false, null, "unknown", null, "Fire suppression speeder", "Emergency Firespeeder", null, "https://swapi.dev/api/vehicles/62/" },
                    { 67, 0, "droid starfighter", "none", 20000, 1, false, 5.4000000000000004, "Colla Designs, Phlac-Arphocc Automata Industries", 1180, "tri-fighter", "Droid tri-fighter", 0, "https://swapi.dev/api/vehicles/67/" },
                    { 69, 50, "airspeeder", "3 days", 12125, 2, false, 15.1, "Appazanna Engineering Works", 420, "Oevvaor jet catamaran", "Oevvaor jet catamaran", 2, "https://swapi.dev/api/vehicles/69/" },
                    { 70, 20, "air speeder", "none", 14750, 2, false, 7.0, "Appazanna Engineering Works", 310, "Raddaugh Gnasp fluttercraft", "Raddaugh Gnasp fluttercraft", 0, "https://swapi.dev/api/vehicles/70/" },
                    { 71, 30000, "wheeled walker", "20 days", 350000, 20, false, 49.399999999999999, "Kuat Drive Yards", 160, "HAVw A6 Juggernaut", "Clone turbo tank", 300, "https://swapi.dev/api/vehicles/71/" },
                    { 72, null, "droid tank", "none", 49000, 0, false, 10.960000000000001, "Techno Union", 100, "NR-N99 Persuader-class droid enforcer", "Corporate Alliance tank droid", 4, "https://swapi.dev/api/vehicles/72/" },
                    { 73, 0, "airspeeder", "none", 60000, 0, false, 12.300000000000001, "Baktoid Fleet Ordnance, Haor Chall Engineering", 820, "HMP droid gunship", "Droid gunship", 0, "https://swapi.dev/api/vehicles/73/" },
                    { 76, 20, "walker", "1 day", 40000, 1, false, 3.2000000000000002, "Kuat Drive Yards", 90, "All Terrain Recon Transport", "AT-RT", 0, "https://swapi.dev/api/vehicles/76/" }
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "BirthYear", "EyeColor", "Gender", "HairColor", "Height", "IsDeleted", "Mass", "Name", "PlanetId", "SkinColor", "Url" },
                values: new object[,]
                {
                    { 1, "19BBY", "blue", "male", "blond", 172, false, 77, "Luke Skywalker", 1, "fair", "https://swapi.dev/api/people/1/" },
                    { 2, "112BBY", "yellow", "n/a", "n/a", 167, false, 75, "C-3PO", 1, "gold", "https://swapi.dev/api/people/2/" },
                    { 3, "33BBY", "red", "n/a", "n/a", 96, false, 32, "R2-D2", 8, "white, blue", "https://swapi.dev/api/people/3/" },
                    { 4, "41.9BBY", "yellow", "male", "none", 202, false, 136, "Darth Vader", 1, "white", "https://swapi.dev/api/people/4/" },
                    { 5, "19BBY", "brown", "female", "brown", 150, false, 49, "Leia Organa", 2, "light", "https://swapi.dev/api/people/5/" },
                    { 6, "52BBY", "blue", "male", "brown, grey", 178, false, 120, "Owen Lars", 1, "light", "https://swapi.dev/api/people/6/" },
                    { 7, "47BBY", "blue", "female", "brown", 165, false, 75, "Beru Whitesun lars", 1, "light", "https://swapi.dev/api/people/7/" },
                    { 8, "unknown", "red", "n/a", "n/a", 97, false, 32, "R5-D4", 1, "white, red", "https://swapi.dev/api/people/8/" },
                    { 9, "24BBY", "brown", "male", "black", 183, false, 84, "Biggs Darklighter", 1, "light", "https://swapi.dev/api/people/9/" },
                    { 10, "57BBY", "blue-gray", "male", "auburn, white", 182, false, 77, "Obi-Wan Kenobi", 20, "fair", "https://swapi.dev/api/people/10/" },
                    { 11, "41.9BBY", "blue", "male", "blond", 188, false, 84, "Anakin Skywalker", 1, "fair", "https://swapi.dev/api/people/11/" },
                    { 12, "64BBY", "blue", "male", "auburn, grey", 180, false, null, "Wilhuff Tarkin", 21, "fair", "https://swapi.dev/api/people/12/" },
                    { 13, "200BBY", "blue", "male", "brown", 228, false, 112, "Chewbacca", 14, "unknown", "https://swapi.dev/api/people/13/" },
                    { 14, "29BBY", "brown", "male", "brown", 180, false, 80, "Han Solo", 22, "fair", "https://swapi.dev/api/people/14/" },
                    { 15, "44BBY", "black", "male", "n/a", 173, false, 74, "Greedo", 23, "green", "https://swapi.dev/api/people/15/" },
                    { 16, "600BBY", "orange", "hermaphrodite", "n/a", 175, false, null, "Jabba Desilijic Tiure", 24, "green-tan, brown", "https://swapi.dev/api/people/16/" },
                    { 18, "21BBY", "hazel", "male", "brown", 170, false, 77, "Wedge Antilles", 22, "fair", "https://swapi.dev/api/people/18/" },
                    { 19, "unknown", "blue", "male", "brown", 180, false, 110, "Jek Tono Porkins", 26, "fair", "https://swapi.dev/api/people/19/" },
                    { 20, "896BBY", "brown", "male", "white", 66, false, 17, "Yoda", 28, "green", "https://swapi.dev/api/people/20/" },
                    { 21, "82BBY", "yellow", "male", "grey", 170, false, 75, "Palpatine", 8, "pale", "https://swapi.dev/api/people/21/" },
                    { 22, "31.5BBY", "brown", "male", "black", 183, false, null, "Boba Fett", 10, "fair", "https://swapi.dev/api/people/22/" },
                    { 23, "15BBY", "red", "none", "none", 200, false, 140, "IG-88", 28, "metal", "https://swapi.dev/api/people/23/" },
                    { 24, "53BBY", "red", "male", "none", 190, false, 113, "Bossk", 29, "green", "https://swapi.dev/api/people/24/" },
                    { 25, "31BBY", "brown", "male", "black", 177, false, 79, "Lando Calrissian", 30, "dark", "https://swapi.dev/api/people/25/" },
                    { 26, "37BBY", "blue", "male", "none", 175, false, 79, "Lobot", 6, "light", "https://swapi.dev/api/people/26/" },
                    { 27, "41BBY", "orange", "male", "none", 180, false, 83, "Ackbar", 31, "brown mottle", "https://swapi.dev/api/people/27/" },
                    { 28, "48BBY", "blue", "female", "auburn", 150, false, null, "Mon Mothma", 32, "fair", "https://swapi.dev/api/people/28/" },
                    { 29, "unknown", "brown", "male", "brown", null, false, null, "Arvel Crynyd", 28, "fair", "https://swapi.dev/api/people/29/" },
                    { 30, "8BBY", "brown", "male", "brown", 88, false, 20, "Wicket Systri Warrick", 7, "brown", "https://swapi.dev/api/people/30/" },
                    { 31, "unknown", "black", "male", "none", 160, false, 68, "Nien Nunb", 33, "grey", "https://swapi.dev/api/people/31/" },
                    { 32, "92BBY", "blue", "male", "brown", 193, false, 89, "Qui-Gon Jinn", 28, "fair", "https://swapi.dev/api/people/32/" },
                    { 33, "unknown", "red", "male", "none", 191, false, 90, "Nute Gunray", 18, "mottled green", "https://swapi.dev/api/people/33/" },
                    { 34, "91BBY", "blue", "male", "blond", 170, false, null, "Finis Valorum", 9, "fair", "https://swapi.dev/api/people/34/" },
                    { 35, "46BBY", "brown", "female", "brown", 185, false, 45, "Padmé Amidala", 8, "light", "https://swapi.dev/api/people/35/" },
                    { 36, "52BBY", "orange", "male", "none", 196, false, 66, "Jar Jar Binks", 8, "orange", "https://swapi.dev/api/people/36/" },
                    { 37, "unknown", "orange", "male", "none", 224, false, 82, "Roos Tarpals", 8, "grey", "https://swapi.dev/api/people/37/" },
                    { 38, "unknown", "orange", "male", "none", 206, false, null, "Rugor Nass", 8, "green", "https://swapi.dev/api/people/38/" },
                    { 39, "unknown", "blue", "male", "brown", 183, false, null, "Ric Olié", 8, "fair", "https://swapi.dev/api/people/39/" },
                    { 40, "unknown", "yellow", "male", "black", 137, false, null, "Watto", 34, "blue, grey", "https://swapi.dev/api/people/40/" },
                    { 41, "unknown", "orange", "male", "none", 112, false, 40, "Sebulba", 35, "grey, red", "https://swapi.dev/api/people/41/" },
                    { 42, "62BBY", "brown", "male", "black", 183, false, null, "Quarsh Panaka", 8, "dark", "https://swapi.dev/api/people/42/" },
                    { 43, "72BBY", "brown", "female", "black", 163, false, null, "Shmi Skywalker", 1, "fair", "https://swapi.dev/api/people/43/" },
                    { 44, "54BBY", "yellow", "male", "none", 175, false, 80, "Darth Maul", 36, "red", "https://swapi.dev/api/people/44/" },
                    { 45, "unknown", "pink", "male", "none", 180, false, null, "Bib Fortuna", 37, "pale", "https://swapi.dev/api/people/45/" },
                    { 46, "48BBY", "hazel", "female", "none", 178, false, 55, "Ayla Secura", 37, "blue", "https://swapi.dev/api/people/46/" },
                    { 47, "unknown", "unknown", "male", "none", 79, false, 15, "Ratts Tyerel", 38, "grey, blue", "https://swapi.dev/api/people/47/" },
                    { 48, "unknown", "yellow", "male", "none", 94, false, 45, "Dud Bolt", 39, "blue, grey", "https://swapi.dev/api/people/48/" },
                    { 49, "unknown", "black", "male", "none", 122, false, null, "Gasgano", 40, "white, blue", "https://swapi.dev/api/people/49/" },
                    { 50, "unknown", "orange", "male", "none", 163, false, 65, "Ben Quadinaros", 41, "grey, green, yellow", "https://swapi.dev/api/people/50/" },
                    { 51, "72BBY", "brown", "male", "none", 188, false, 84, "Mace Windu", 42, "dark", "https://swapi.dev/api/people/51/" },
                    { 52, "92BBY", "yellow", "male", "white", 198, false, 82, "Ki-Adi-Mundi", 43, "pale", "https://swapi.dev/api/people/52/" },
                    { 53, "unknown", "black", "male", "none", 196, false, 87, "Kit Fisto", 44, "green", "https://swapi.dev/api/people/53/" },
                    { 54, "unknown", "brown", "male", "black", 171, false, null, "Eeth Koth", 45, "brown", "https://swapi.dev/api/people/54/" },
                    { 55, "unknown", "blue", "female", "none", 184, false, 50, "Adi Gallia", 9, "dark", "https://swapi.dev/api/people/55/" },
                    { 56, "unknown", "orange", "male", "none", 188, false, null, "Saesee Tiin", 47, "pale", "https://swapi.dev/api/people/56/" },
                    { 57, "unknown", "yellow", "male", "none", 264, false, null, "Yarael Poof", 48, "white", "https://swapi.dev/api/people/57/" },
                    { 58, "22BBY", "black", "male", "none", 188, false, 80, "Plo Koon", 49, "orange", "https://swapi.dev/api/people/58/" },
                    { 59, "unknown", "blue", "male", "none", 196, false, null, "Mas Amedda", 50, "blue", "https://swapi.dev/api/people/59/" },
                    { 60, "unknown", "brown", "male", "black", 185, false, 85, "Gregar Typho", 8, "dark", "https://swapi.dev/api/people/60/" },
                    { 61, "unknown", "brown", "female", "brown", 157, false, null, "Cordé", 8, "light", "https://swapi.dev/api/people/61/" },
                    { 62, "82BBY", "blue", "male", "brown", 183, false, null, "Cliegg Lars", 1, "fair", "https://swapi.dev/api/people/62/" },
                    { 63, "unknown", "yellow", "male", "none", 183, false, 80, "Poggle the Lesser", 11, "green", "https://swapi.dev/api/people/63/" },
                    { 64, "58BBY", "blue", "female", "black", 170, false, null, "Luminara Unduli", 51, "yellow", "https://swapi.dev/api/people/64/" },
                    { 65, "40BBY", "blue", "female", "black", 166, false, 50, "Barriss Offee", 51, "yellow", "https://swapi.dev/api/people/65/" },
                    { 66, "unknown", "brown", "female", "brown", 165, false, null, "Dormé", 8, "light", "https://swapi.dev/api/people/66/" },
                    { 67, "102BBY", "brown", "male", "white", 193, false, 80, "Dooku", 52, "fair", "https://swapi.dev/api/people/67/" },
                    { 68, "67BBY", "brown", "male", "black", 191, false, null, "Bail Prestor Organa", 2, "tan", "https://swapi.dev/api/people/68/" },
                    { 69, "66BBY", "brown", "male", "black", 183, false, 79, "Jango Fett", 53, "tan", "https://swapi.dev/api/people/69/" },
                    { 70, "unknown", "yellow", "female", "blonde", 168, false, 55, "Zam Wesell", 54, "fair, green, yellow", "https://swapi.dev/api/people/70/" },
                    { 71, "unknown", "yellow", "male", "none", 198, false, 102, "Dexter Jettster", 55, "brown", "https://swapi.dev/api/people/71/" },
                    { 72, "unknown", "black", "male", "none", 229, false, 88, "Lama Su", 10, "grey", "https://swapi.dev/api/people/72/" },
                    { 73, "unknown", "black", "female", "none", 213, false, null, "Taun We", 10, "grey", "https://swapi.dev/api/people/73/" },
                    { 74, "unknown", "blue", "female", "white", 167, false, null, "Jocasta Nu", 9, "fair", "https://swapi.dev/api/people/74/" },
                    { 75, "unknown", "red, blue", "female", "none", 96, false, null, "R4-P17", 28, "silver, red", "https://swapi.dev/api/people/75/" },
                    { 76, "unknown", "unknown", "male", "none", 193, false, 48, "Wat Tambor", 56, "green, grey", "https://swapi.dev/api/people/76/" },
                    { 77, "unknown", "gold", "male", "none", 191, false, null, "San Hill", 57, "grey", "https://swapi.dev/api/people/77/" },
                    { 78, "unknown", "black", "female", "none", 178, false, 57, "Shaak Ti", 58, "red, blue, white", "https://swapi.dev/api/people/78/" },
                    { 79, "unknown", "green, yellow", "male", "none", 216, false, 159, "Grievous", 59, "brown, white", "https://swapi.dev/api/people/79/" },
                    { 80, "unknown", "blue", "male", "brown", 234, false, 136, "Tarfful", 14, "brown", "https://swapi.dev/api/people/80/" },
                    { 81, "unknown", "brown", "male", "brown", 188, false, 79, "Raymus Antilles", 2, "light", "https://swapi.dev/api/people/81/" },
                    { 82, "unknown", "white", "female", "none", 178, false, 48, "Sly Moore", 60, "pale", "https://swapi.dev/api/people/82/" },
                    { 83, "unknown", "black", "male", "none", 206, false, 80, "Tion Medon", 12, "grey", "https://swapi.dev/api/people/83/" }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "AverageHeight", "AverageLifespan", "Classification", "Designation", "EyeColors", "HairColors", "IsDeleted", "Language", "Name", "PlanetId", "SkinColors", "Url" },
                values: new object[,]
                {
                    { 1, "180", "120", "mammal", "sentient", "brown, blue, green, hazel, grey, amber", "blonde, brown, black, red", false, "Galactic Basic", "Human", 9, "caucasian, black, asian, hispanic", "https://swapi.dev/api/species/1/" },
                    { 3, "210", "400", "mammal", "sentient", "blue, green, yellow, brown, golden, red", "black, brown", false, "Shyriiwook", "Wookie", 14, "gray", "https://swapi.dev/api/species/3/" },
                    { 4, "170", "unknown", "sentient", "reptilian", "black", "n/a", false, "Galatic Basic", "Rodian", 23, "green, blue", "https://swapi.dev/api/species/4/" },
                    { 5, "300", "1000", "gastropod", "sentient", "yellow, red", "n/a", false, "Huttese", "Hutt", 24, "green, brown, tan", "https://swapi.dev/api/species/5/" },
                    { 6, "66", "900", "mammal", "sentient", "brown, green, yellow", "brown, white", false, "Galactic basic", "Yoda's species", 28, "green, yellow", "https://swapi.dev/api/species/6/" },
                    { 7, "200", "unknown", "reptile", "sentient", "yellow, orange", "none", false, "Dosh", "Trandoshan", 29, "brown, green", "https://swapi.dev/api/species/7/" },
                    { 8, "160", "unknown", "amphibian", "sentient", "yellow", "none", false, "Mon Calamarian", "Mon Calamari", 31, "red, blue, brown, magenta", "https://swapi.dev/api/species/8/" },
                    { 9, "100", "unknown", "mammal", "sentient", "orange, brown", "white, brown, black", false, "Ewokese", "Ewok", 7, "brown", "https://swapi.dev/api/species/9/" },
                    { 10, "180", "unknown", "mammal", "sentient", "black", "none", false, "Sullutese", "Sullustan", 33, "pale", "https://swapi.dev/api/species/10/" },
                    { 11, "180", "unknown", "unknown", "sentient", "red, pink", "none", false, "Neimoidia", "Neimodian", 18, "grey, green", "https://swapi.dev/api/species/11/" },
                    { 12, "190", "unknown", "amphibian", "sentient", "orange", "none", false, "Gungan basic", "Gungan", 8, "brown, green", "https://swapi.dev/api/species/12/" },
                    { 13, "120", "91", "mammal", "sentient", "yellow", "none", false, "Toydarian", "Toydarian", 34, "blue, green, grey", "https://swapi.dev/api/species/13/" },
                    { 14, "100", "unknown", "mammal", "sentient", "yellow, blue", "none", false, "Dugese", "Dug", 35, "brown, purple, grey, red", "https://swapi.dev/api/species/14/" },
                    { 15, "200", "unknown", "mammals", "sentient", "blue, brown, orange, pink", "none", false, "Twi'leki", "Twi'lek", 37, "orange, yellow, blue, green, pink, purple, tan", "https://swapi.dev/api/species/15/" },
                    { 16, "80", "79", "reptile", "sentient", "unknown", "none", false, "Aleena", "Aleena", 38, "blue, gray", "https://swapi.dev/api/species/16/" },
                    { 17, "100", "unknown", "unknown", "sentient", "yellow", "none", false, "vulpterish", "Vulptereen", 39, "grey", "https://swapi.dev/api/species/17/" },
                    { 18, "125", "unknown", "unknown", "sentient", "black", "none", false, "Xextese", "Xexto", 40, "grey, yellow, purple", "https://swapi.dev/api/species/18/" },
                    { 19, "200", "unknown", "unknown", "sentient", "orange", "none", false, "Tundan", "Toong", 41, "grey, green, yellow", "https://swapi.dev/api/species/19/" },
                    { 20, "200", "unknown", "mammal", "sentient", "hazel", "red, blond, black, white", false, "Cerean", "Cerean", 43, "pale pink", "https://swapi.dev/api/species/20/" },
                    { 21, "180", "70", "amphibian", "sentient", "black", "none", false, "Nautila", "Nautolan", 44, "green, blue, brown, red", "https://swapi.dev/api/species/21/" },
                    { 22, "180", "unknown", "mammal", "sentient", "brown, orange", "black", false, "Zabraki", "Zabrak", 45, "pale, brown, red, orange, yellow", "https://swapi.dev/api/species/22/" },
                    { 23, "unknown", "unknown", "mammal", "sentient", "blue, indigo", "unknown", false, "unknown", "Tholothian", 46, "dark", "https://swapi.dev/api/species/23/" },
                    { 24, "180", "unknown", "unknown", "sentient", "orange", "none", false, "Iktotchese", "Iktotchi", 47, "pink", "https://swapi.dev/api/species/24/" },
                    { 25, "240", "86", "mammal", "sentient", "yellow", "none", false, "Quermian", "Quermian", 48, "white", "https://swapi.dev/api/species/25/" },
                    { 26, "180", "70", "unknown", "sentient", "black, silver", "none", false, "Kel Dor", "Kel Dor", 49, "peach, orange, red", "https://swapi.dev/api/species/26/" },
                    { 27, "190", "unknown", "amphibian", "sentient", "blue", "none", false, "Chagria", "Chagrian", 50, "blue", "https://swapi.dev/api/species/27/" },
                    { 28, "178", "unknown", "insectoid", "sentient", "green, hazel", "none", false, "Geonosian", "Geonosian", 11, "green, brown", "https://swapi.dev/api/species/28/" },
                    { 29, "180", "unknown", "mammal", "sentient", "blue, green, red, yellow, brown, orange", "black, brown", false, "Mirialan", "Mirialan", 51, "yellow, green", "https://swapi.dev/api/species/29/" },
                    { 30, "180", "70", "reptilian", "sentient", "yellow", "none", false, "Clawdite", "Clawdite", 54, "green, yellow", "https://swapi.dev/api/species/30/" },
                    { 31, "178", "75", "amphibian", "sentient", "yellow", "none", false, "besalisk", "Besalisk", 55, "brown", "https://swapi.dev/api/species/31/" },
                    { 32, "220", "80", "amphibian", "sentient", "black", "none", false, "Kaminoan", "Kaminoan", 10, "grey, blue", "https://swapi.dev/api/species/32/" },
                    { 33, "unknown", "unknown", "mammal", "sentient", "unknown", "none", false, "Skakoan", "Skakoan", 56, "grey, green", "https://swapi.dev/api/species/33/" },
                    { 34, "190", "100", "mammal", "sentient", "black", "none", false, "Muun", "Muun", 57, "grey, white", "https://swapi.dev/api/species/34/" },
                    { 35, "180", "94", "mammal", "sentient", "red, orange, yellow, green, blue, black", "none", false, "Togruti", "Togruta", 58, "red, white, orange, yellow, green, blue", "https://swapi.dev/api/species/35/" },
                    { 36, "170", "80", "reptile", "sentient", "yellow", "none", false, "Kaleesh", "Kaleesh", 59, "brown, orange, tan", "https://swapi.dev/api/species/36/" },
                    { 37, "190", "700", "mammal", "sentient", "black", "none", false, "Utapese", "Pau'an", 12, "grey", "https://swapi.dev/api/species/37/" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMovie_MoviesId",
                table: "CharacterMovie",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_PlanetId",
                table: "Characters",
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

            migrationBuilder.CreateIndex(
                name: "IX_MoviePlanet_PlanetsId",
                table: "MoviePlanet",
                column: "PlanetsId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSpecie_SpeciesId",
                table: "MovieSpecie",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieStarship_StarshipsId",
                table: "MovieStarship",
                column: "StarshipsId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieVehicle_VehiclesId",
                table: "MovieVehicle",
                column: "VehiclesId");

            migrationBuilder.CreateIndex(
                name: "IX_Species_PlanetId",
                table: "Species",
                column: "PlanetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CharacterMovie");

            migrationBuilder.DropTable(
                name: "CharacterSpecie");

            migrationBuilder.DropTable(
                name: "CharacterStarship");

            migrationBuilder.DropTable(
                name: "CharacterVehicle");

            migrationBuilder.DropTable(
                name: "MoviePlanet");

            migrationBuilder.DropTable(
                name: "MovieSpecie");

            migrationBuilder.DropTable(
                name: "MovieStarship");

            migrationBuilder.DropTable(
                name: "MovieVehicle");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "Starships");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Planets");
        }
    }
}
