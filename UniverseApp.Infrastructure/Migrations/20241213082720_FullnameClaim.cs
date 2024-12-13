using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniverseApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FullnameClaim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "user:fullname", "Yoda Master", "cfcc5c95-4666-4fe1-b26a-50c4016dac21" },
                    { 2, "user:fullname", "First User", "18990560-1cca-49b8-b4db-5adb987559c3" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "18990560-1cca-49b8-b4db-5adb987559c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85c2f945-4484-490c-a1c5-13d7e8f59cf3", "AQAAAAIAAYagAAAAEC1O7a4GIrNDJrDk6WbPfVwYN5YFxUGSPFxzDkZnIc/HCKidNIgRoPIY4ZU4/7hDKg==", "6932ee70-f603-4a04-ba33-11a7a5707e27" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfcc5c95-4666-4fe1-b26a-50c4016dac21",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "acc237c9-a926-4dce-b92c-aa3d02d1aab7", "AQAAAAIAAYagAAAAEKaSb55ZkskvFrs+v4mWPK9V6NDr3fulod5H3J69obDuItYWIdfH0PfFroUZ21FR0Q==", "e763823f-afd7-46f9-a44b-b961c65a7f2a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "18990560-1cca-49b8-b4db-5adb987559c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11a15df7-7d92-4322-aed8-16f55f398abf", "AQAAAAIAAYagAAAAEMjI+iw3AaIo71dVU9iec2RIYavofAG/fE1gmksOGF2CigagUvDXCvwGMjRAcZZ3wg==", "6d6259a9-f9bf-41c3-a68c-b0ea09fc48ca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfcc5c95-4666-4fe1-b26a-50c4016dac21",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6af265c6-4c7d-4463-9366-d1823d524c3e", "AQAAAAIAAYagAAAAELOH3T2go4asKSsPoVyxWq7s+dBQGcD3wn0hULW99B2l2pIetIdXaNPMfh1x1cCtDQ==", "b24a61e4-75e8-4e7d-a7ba-fc9c90821020" });
        }
    }
}
