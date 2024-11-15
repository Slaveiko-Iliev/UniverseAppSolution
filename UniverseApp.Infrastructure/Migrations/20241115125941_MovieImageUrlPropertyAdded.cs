using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniverseApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MovieImageUrlPropertyAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Vehicles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Vehicle URL",
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70,
                oldComment: "Vehicle URL");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Starships",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Vehicle URL",
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70,
                oldComment: "Vehicle URL");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Species",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Specie Url",
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70,
                oldComment: "Specie Url");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Planets",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Planet Url",
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70,
                oldComment: "Planet Url");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Movies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Movies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Characters",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Character Url",
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70,
                oldComment: "Character Url");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Movies");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Vehicles",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                comment: "Vehicle URL",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Vehicle URL");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Starships",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                comment: "Vehicle URL",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Vehicle URL");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Species",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                comment: "Specie Url",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Specie Url");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Planets",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                comment: "Planet Url",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Planet Url");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Movies",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Characters",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                comment: "Character Url",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Character Url");
        }
    }
}
