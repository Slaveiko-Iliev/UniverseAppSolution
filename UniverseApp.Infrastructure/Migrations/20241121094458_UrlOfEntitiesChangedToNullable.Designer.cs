﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniverseApp.Infrastructure.Data;

#nullable disable

namespace UniverseApp.Infrastructure.Migrations
{
    [DbContext(typeof(UniverseDbContext))]
    [Migration("20241121094458_UrlOfEntitiesChangedToNullable")]
    partial class UrlOfEntitiesChangedToNullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.Property<int>("CharactersId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("CharactersId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("CharacterMovie");
                });

            modelBuilder.Entity("CharacterSpecie", b =>
                {
                    b.Property<int>("CharactersId")
                        .HasColumnType("int");

                    b.Property<int>("SpeciesId")
                        .HasColumnType("int");

                    b.HasKey("CharactersId", "SpeciesId");

                    b.HasIndex("SpeciesId");

                    b.ToTable("CharacterSpecie");
                });

            modelBuilder.Entity("CharacterStarship", b =>
                {
                    b.Property<int>("CharactersId")
                        .HasColumnType("int");

                    b.Property<int>("StarshipsId")
                        .HasColumnType("int");

                    b.HasKey("CharactersId", "StarshipsId");

                    b.HasIndex("StarshipsId");

                    b.ToTable("CharacterStarship");
                });

            modelBuilder.Entity("CharacterVehicle", b =>
                {
                    b.Property<int>("CharactersId")
                        .HasColumnType("int");

                    b.Property<int>("VehiclesId")
                        .HasColumnType("int");

                    b.HasKey("CharactersId", "VehiclesId");

                    b.HasIndex("VehiclesId");

                    b.ToTable("CharacterVehicle");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MoviePlanet", b =>
                {
                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.Property<int>("PlanetsId")
                        .HasColumnType("int");

                    b.HasKey("MoviesId", "PlanetsId");

                    b.HasIndex("PlanetsId");

                    b.ToTable("MoviePlanet");
                });

            modelBuilder.Entity("MovieSpecie", b =>
                {
                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.Property<int>("SpeciesId")
                        .HasColumnType("int");

                    b.HasKey("MoviesId", "SpeciesId");

                    b.HasIndex("SpeciesId");

                    b.ToTable("MovieSpecie");
                });

            modelBuilder.Entity("MovieStarship", b =>
                {
                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.Property<int>("StarshipsId")
                        .HasColumnType("int");

                    b.HasKey("MoviesId", "StarshipsId");

                    b.HasIndex("StarshipsId");

                    b.ToTable("MovieStarship");
                });

            modelBuilder.Entity("MovieVehicle", b =>
                {
                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.Property<int>("VehiclesId")
                        .HasColumnType("int");

                    b.HasKey("MoviesId", "VehiclesId");

                    b.HasIndex("VehiclesId");

                    b.ToTable("MovieVehicle");
                });

            modelBuilder.Entity("UniverseApp.Infrastructure.Data.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasComment("Character Identifier");

                    b.Property<string>("BirthYear")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasComment("Character Birth Year");

                    b.Property<string>("EyeColor")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Character Eye Color");

                    b.Property<string>("Gender")
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)")
                        .HasComment("Character Gender");

                    b.Property<string>("HairColor")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Character Hair Color");

                    b.Property<int?>("Height")
                        .HasColumnType("int")
                        .HasComment("Character Height");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("Whether the Entity has been deleted");

                    b.Property<int?>("Mass")
                        .HasColumnType("int")
                        .HasComment("Character Mass");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Character Name");

                    b.Property<int?>("PlanetId")
                        .HasColumnType("int")
                        .HasComment("Character Home Planet");

                    b.Property<string>("SkinColor")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Character Skin Color");

                    b.Property<string>("Url")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Character Url");

                    b.HasKey("Id");

                    b.HasIndex("PlanetId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("UniverseApp.Infrastructure.Data.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasComment("Movie Identifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Movie Description");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Movie Director");

                    b.Property<string>("EpisodeId")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasComment("Movie Episode Identifier");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Movie Image Url");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("Whether the Entity has been deleted");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Movie Producer");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2")
                        .HasComment("Movie Release Date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasComment("Movie Title");

                    b.Property<string>("Url")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Movies", t =>
                        {
                            t.HasComment("Movie Entity");
                        });
                });

            modelBuilder.Entity("UniverseApp.Infrastructure.Data.Models.Planet", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasComment("Movie Identifier");

                    b.Property<string>("Climate")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Climate of Planet");

                    b.Property<string>("Gravity")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Gravity of Planet");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("Whether the Entity has been deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Planet Name");

                    b.Property<int?>("OrbitalPeriod")
                        .HasMaxLength(7)
                        .HasColumnType("int")
                        .HasComment("Orbital Period of Planet");

                    b.Property<int?>("Population")
                        .HasMaxLength(15)
                        .HasColumnType("int")
                        .HasComment("Population of Planet");

                    b.Property<int?>("RotationPeriod")
                        .HasMaxLength(7)
                        .HasColumnType("int")
                        .HasComment("Rotation Period of Planet");

                    b.Property<decimal?>("SurfaceWater")
                        .HasMaxLength(7)
                        .HasColumnType("decimal(5, 2)")
                        .HasComment("Surface Water of Planet");

                    b.Property<string>("Terrain")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasComment("Terrain of Planet");

                    b.Property<string>("Url")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Planet Url");

                    b.HasKey("Id");

                    b.ToTable("Planets");
                });

            modelBuilder.Entity("UniverseApp.Infrastructure.Data.Models.Specie", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasComment("Specie Identifier");

                    b.Property<string>("AverageHeight")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)")
                        .HasComment("Specie Average Height");

                    b.Property<string>("AverageLifespan")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)")
                        .HasComment("Specie Average Lifespan");

                    b.Property<string>("Classification")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Specie Classification");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Specie Designation");

                    b.Property<string>("EyeColors")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Specie EyeColor");

                    b.Property<string>("HairColors")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Specie HairColor");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("Whether the Entity has been deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Specie Name");

                    b.Property<int?>("PlanetId")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasComment("Specie Homeworld");

                    b.Property<string>("SkinColors")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Specie SkinColor");

                    b.Property<string>("Url")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Specie Url");

                    b.HasKey("Id");

                    b.HasIndex("PlanetId");

                    b.ToTable("Species");
                });

            modelBuilder.Entity("UniverseApp.Infrastructure.Data.Models.Starship", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasComment("Vehicle Identifier");

                    b.Property<int?>("CargoCapacity")
                        .HasMaxLength(15)
                        .HasColumnType("int")
                        .HasComment("Vehicle Cargo Capacity");

                    b.Property<string>("Class")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Vehicle Class");

                    b.Property<string>("Consumables")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Vehicle Consumables");

                    b.Property<int?>("CostInCredits")
                        .HasMaxLength(15)
                        .HasColumnType("int")
                        .HasComment("Vehicle Cost In Credits");

                    b.Property<int?>("Crew")
                        .HasMaxLength(10)
                        .HasColumnType("int")
                        .HasComment("Vehicle Crew");

                    b.Property<double?>("HyperdriveRating")
                        .HasMaxLength(3)
                        .HasColumnType("float")
                        .HasComment("Starship Hyperdrive Rating");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("Whether the Entity has been deleted");

                    b.Property<double?>("Length")
                        .HasMaxLength(7)
                        .HasColumnType("float")
                        .HasComment("Vehicle Length");

                    b.Property<int?>("MGLT")
                        .HasMaxLength(3)
                        .HasColumnType("int")
                        .HasComment("Starship MGLT");

                    b.Property<string>("Manufacturer")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Vehicle Manufacturer");

                    b.Property<int?>("MaxAtmospheringSpeed")
                        .HasMaxLength(4)
                        .HasColumnType("int")
                        .HasComment("Vehicle Max Atmosphering Speed");

                    b.Property<string>("Model")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasComment("Vehicle Model");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasComment("Vehicle Name");

                    b.Property<int?>("Passengers")
                        .HasMaxLength(10)
                        .HasColumnType("int")
                        .HasComment("Vehicle Passengers");

                    b.Property<string>("Url")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Vehicle URL");

                    b.HasKey("Id");

                    b.ToTable("Starships");
                });

            modelBuilder.Entity("UniverseApp.Infrastructure.Data.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasComment("Vehicle Identifier");

                    b.Property<int?>("CargoCapacity")
                        .HasMaxLength(15)
                        .HasColumnType("int")
                        .HasComment("Vehicle Cargo Capacity");

                    b.Property<string>("Class")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Vehicle Class");

                    b.Property<string>("Consumables")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Vehicle Consumables");

                    b.Property<int?>("CostInCredits")
                        .HasMaxLength(15)
                        .HasColumnType("int")
                        .HasComment("Vehicle Cost In Credits");

                    b.Property<int?>("Crew")
                        .HasMaxLength(10)
                        .HasColumnType("int")
                        .HasComment("Vehicle Crew");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("Whether the Entity has been deleted");

                    b.Property<double?>("Length")
                        .HasMaxLength(7)
                        .HasColumnType("float")
                        .HasComment("Vehicle Length");

                    b.Property<string>("Manufacturer")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Vehicle Manufacturer");

                    b.Property<int?>("MaxAtmospheringSpeed")
                        .HasMaxLength(4)
                        .HasColumnType("int")
                        .HasComment("Vehicle Max Atmosphering Speed");

                    b.Property<string>("Model")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasComment("Vehicle Model");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasComment("Vehicle Name");

                    b.Property<int?>("Passengers")
                        .HasMaxLength(10)
                        .HasColumnType("int")
                        .HasComment("Vehicle Passengers");

                    b.Property<string>("Url")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Vehicle URL");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.HasOne("UniverseApp.Infrastructure.Data.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniverseApp.Infrastructure.Data.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CharacterSpecie", b =>
                {
                    b.HasOne("UniverseApp.Infrastructure.Data.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniverseApp.Infrastructure.Data.Models.Specie", null)
                        .WithMany()
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CharacterStarship", b =>
                {
                    b.HasOne("UniverseApp.Infrastructure.Data.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniverseApp.Infrastructure.Data.Models.Starship", null)
                        .WithMany()
                        .HasForeignKey("StarshipsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CharacterVehicle", b =>
                {
                    b.HasOne("UniverseApp.Infrastructure.Data.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniverseApp.Infrastructure.Data.Models.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehiclesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MoviePlanet", b =>
                {
                    b.HasOne("UniverseApp.Infrastructure.Data.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniverseApp.Infrastructure.Data.Models.Planet", null)
                        .WithMany()
                        .HasForeignKey("PlanetsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieSpecie", b =>
                {
                    b.HasOne("UniverseApp.Infrastructure.Data.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniverseApp.Infrastructure.Data.Models.Specie", null)
                        .WithMany()
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieStarship", b =>
                {
                    b.HasOne("UniverseApp.Infrastructure.Data.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniverseApp.Infrastructure.Data.Models.Starship", null)
                        .WithMany()
                        .HasForeignKey("StarshipsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieVehicle", b =>
                {
                    b.HasOne("UniverseApp.Infrastructure.Data.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniverseApp.Infrastructure.Data.Models.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehiclesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UniverseApp.Infrastructure.Data.Models.Character", b =>
                {
                    b.HasOne("UniverseApp.Infrastructure.Data.Models.Planet", "Planet")
                        .WithMany("Characters")
                        .HasForeignKey("PlanetId");

                    b.Navigation("Planet");
                });

            modelBuilder.Entity("UniverseApp.Infrastructure.Data.Models.Specie", b =>
                {
                    b.HasOne("UniverseApp.Infrastructure.Data.Models.Planet", "Planet")
                        .WithMany()
                        .HasForeignKey("PlanetId");

                    b.Navigation("Planet");
                });

            modelBuilder.Entity("UniverseApp.Infrastructure.Data.Models.Planet", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
