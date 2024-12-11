using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniverseApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PadawanRoleAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "234e651b-2617-450d-838e-b8a6d072b35c", null, "Padawan", "PADAWAN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "18990560-1cca-49b8-b4db-5adb987559c3",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11a15df7-7d92-4322-aed8-16f55f398abf", true, "AQAAAAIAAYagAAAAEMjI+iw3AaIo71dVU9iec2RIYavofAG/fE1gmksOGF2CigagUvDXCvwGMjRAcZZ3wg==", "6d6259a9-f9bf-41c3-a68c-b0ea09fc48ca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfcc5c95-4666-4fe1-b26a-50c4016dac21",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6af265c6-4c7d-4463-9366-d1823d524c3e", "AQAAAAIAAYagAAAAELOH3T2go4asKSsPoVyxWq7s+dBQGcD3wn0hULW99B2l2pIetIdXaNPMfh1x1cCtDQ==", "b24a61e4-75e8-4e7d-a7ba-fc9c90821020" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "234e651b-2617-450d-838e-b8a6d072b35c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "18990560-1cca-49b8-b4db-5adb987559c3",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4e93f9c-b4c6-4138-92e0-916c93e76466", false, "AQAAAAIAAYagAAAAEM5RX1m7tzs+2njtf2wET+YnjkvfBKIiy9j1567nQvH/izAKYr/QL8iw7S/ZSbrdWQ==", "2798d7ca-8871-4a25-a423-fb2c9f6c8bb6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfcc5c95-4666-4fe1-b26a-50c4016dac21",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0233935d-4a77-4a85-b1e2-9beacb0cd775", "AQAAAAIAAYagAAAAEF2S8Q4SA3uMldvJF209S6ybmiabZU+zstBLvA5TDF6p4OHx/Q16zi1grjMmpyq2KA==", "3c0378e8-8201-4fd2-a559-e4a66a10c07e" });
        }
    }
}
