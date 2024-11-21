using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniverseApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UrlOfEntitiesChangedToNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Vehicles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Vehicle URL",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Vehicle URL");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Starships",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Vehicle URL",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Vehicle URL");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Species",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Specie Url",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Specie Url");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Movies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Movies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Movie Image Url",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "EpisodeId",
                table: "Movies",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                comment: "Movie Episode Identifier",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Movie Episode Identifier");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Characters",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Character Url",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Character Url");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Vehicles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "Vehicle URL",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "Vehicle URL");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Starships",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "Vehicle URL",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "Vehicle URL");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Species",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "Specie Url",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "Specie Url");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Movies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Movies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Movie Image Url");

            migrationBuilder.AlterColumn<int>(
                name: "EpisodeId",
                table: "Movies",
                type: "int",
                nullable: false,
                comment: "Movie Episode Identifier",
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2,
                oldComment: "Movie Episode Identifier");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Characters",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "Character Url",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "Character Url");
        }
    }
}
