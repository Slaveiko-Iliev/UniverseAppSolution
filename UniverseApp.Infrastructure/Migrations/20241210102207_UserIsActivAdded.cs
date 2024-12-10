using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniverseApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserIsActivAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is the user active");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "18990560-1cca-49b8-b4db-5adb987559c3",
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4e93f9c-b4c6-4138-92e0-916c93e76466", true, "AQAAAAIAAYagAAAAEM5RX1m7tzs+2njtf2wET+YnjkvfBKIiy9j1567nQvH/izAKYr/QL8iw7S/ZSbrdWQ==", "2798d7ca-8871-4a25-a423-fb2c9f6c8bb6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfcc5c95-4666-4fe1-b26a-50c4016dac21",
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0233935d-4a77-4a85-b1e2-9beacb0cd775", true, "AQAAAAIAAYagAAAAEF2S8Q4SA3uMldvJF209S6ybmiabZU+zstBLvA5TDF6p4OHx/Q16zi1grjMmpyq2KA==", "3c0378e8-8201-4fd2-a559-e4a66a10c07e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "18990560-1cca-49b8-b4db-5adb987559c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4940d66f-593f-4021-8526-629f94158e32", "AQAAAAIAAYagAAAAEKSmu0jnrWNDXxuBnn2T9walsEgWPJGB5hU1Mizj0Fuo1pNAo6Vkh6ztjOIugI8TAg==", "6ee7a2f0-be65-45df-b25e-422865ebd905" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfcc5c95-4666-4fe1-b26a-50c4016dac21",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "666b2bae-44dc-4ad1-b56d-6316d2c92534", "AQAAAAIAAYagAAAAENikkkfqHvH6+bTJ3WJIDmj0XwWFCzRtsA2LvE5sHGCP5QoBb3lJlGyJrlNUTzURvQ==", "a8837600-0786-4d5c-adc3-26e03d0600fe" });
        }
    }
}
