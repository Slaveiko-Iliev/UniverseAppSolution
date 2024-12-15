using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniverseApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MovieAndSpeciePropertiesChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Movies",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "AverageLifespan",
                table: "Species",
                type: "int",
                maxLength: 4,
                nullable: true,
                comment: "Specie Average Lifespan",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true,
                oldComment: "Specie Average Lifespan");

            migrationBuilder.AlterColumn<int>(
                name: "AverageHeight",
                table: "Species",
                type: "int",
                maxLength: 3,
                nullable: true,
                comment: "Specie Average Height",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true,
                oldComment: "Specie Average Height");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is the user active");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Movies",
                newName: "Title");

            migrationBuilder.AlterColumn<string>(
                name: "AverageLifespan",
                table: "Species",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                comment: "Specie Average Lifespan",
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 4,
                oldNullable: true,
                oldComment: "Specie Average Lifespan");

            migrationBuilder.AlterColumn<string>(
                name: "AverageHeight",
                table: "Species",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                comment: "Specie Average Height",
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 3,
                oldNullable: true,
                oldComment: "Specie Average Height");
        }
    }
}
