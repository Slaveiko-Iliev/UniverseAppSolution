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
                    FirstName = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Is the user active"),
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
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Movie Title"),
                    EpisodeId = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false, comment: "Movie Episode Identifier"),
                    Description = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false, comment: "Movie Description"),
                    Director = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Movie Director"),
                    Producer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Movie Producer"),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Movie Release Date"),
                    Url = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Movie Image Url"),
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
                    AverageHeight = table.Column<int>(type: "int", maxLength: 3, nullable: true, comment: "Specie Average Height"),
                    SkinColors = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Specie SkinColor"),
                    HairColors = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Specie HairColor"),
                    EyeColors = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Specie EyeColor"),
                    AverageLifespan = table.Column<int>(type: "int", maxLength: 4, nullable: true, comment: "Specie Average Lifespan"),
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "234e651b-2617-450d-838e-b8a6d072b35c", null, "Padawan", "PADAWAN" },
                    { "6468123d-a641-4305-9a52-533361297ed3", null, "Yoda", "YODA" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "18990560-1cca-49b8-b4db-5adb987559c3", 0, "110f1c3e-d794-4ef3-96d2-507a8444c670", "user@mail.com", true, "First", true, "User", false, null, "USER@MAIL.COM", "USER@MAIL.COM", "AQAAAAIAAYagAAAAENQflYYTTCHHxJZy/JCxARVZZHWabKNqU8dGt9mTV0NA5d3vUpiR8jrCiBPUWpvoIQ==", null, false, "16fc401b-aab9-4a22-b8e6-3559a4c9741a", false, "user@mail.com" },
                    { "cfcc5c95-4666-4fe1-b26a-50c4016dac21", 0, "c8a02291-e9e2-416a-97e8-1ed44ed2fa8e", "yoda@mail.com", true, "Yoda", true, "Master", false, null, "YODA@MAIL.COM", "YODA@MAIL.COM", "AQAAAAIAAYagAAAAELtMPX1Kif5VwliqSeTA1GAwqypizyU5tNLCp72YVVC0GLNraJO7lUfmEuivmIK1Fw==", null, false, "0686fddf-1214-481f-a78d-8d53aa9aa0ea", false, "yoda@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "user:fullname", "Yoda Master", "cfcc5c95-4666-4fe1-b26a-50c4016dac21" },
                    { 2, "user:fullname", "First User", "18990560-1cca-49b8-b4db-5adb987559c3" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6468123d-a641-4305-9a52-533361297ed3", "cfcc5c95-4666-4fe1-b26a-50c4016dac21" });

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
