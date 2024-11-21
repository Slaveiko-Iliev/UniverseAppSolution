using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniverseApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PlanetPropertiesCorrected : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Planets",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Planet Url",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Planet Url");

            migrationBuilder.AlterColumn<string>(
                name: "Terrain",
                table: "Planets",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true,
                comment: "Terrain of Planet",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Terrain of Planet");

            migrationBuilder.AlterColumn<string>(
                name: "Gravity",
                table: "Planets",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "Gravity of Planet",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Gravity of Planet");

            migrationBuilder.AlterColumn<string>(
                name: "Climate",
                table: "Planets",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                comment: "Climate of Planet",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Climate of Planet");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Planets",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "Planet Url",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "Planet Url");

            migrationBuilder.AlterColumn<string>(
                name: "Terrain",
                table: "Planets",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "Terrain of Planet",
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60,
                oldNullable: true,
                oldComment: "Terrain of Planet");

            migrationBuilder.AlterColumn<string>(
                name: "Gravity",
                table: "Planets",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "Gravity of Planet",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldComment: "Gravity of Planet");

            migrationBuilder.AlterColumn<string>(
                name: "Climate",
                table: "Planets",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "Climate of Planet",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true,
                oldComment: "Climate of Planet");
        }
    }
}
