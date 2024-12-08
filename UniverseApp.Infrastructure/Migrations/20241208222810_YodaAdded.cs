using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniverseApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class YodaAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6468123d-a641-4305-9a52-533361297ed3", null, "Yoda", "YODA" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "18990560-1cca-49b8-b4db-5adb987559c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ebf8102-dc4c-4c5e-9fc6-a230abcbd5c8", "AQAAAAIAAYagAAAAEPUkCigEBBAitjCxSdWy6lMud9FVZqiFiWxzEwlWYK5DpRpBN6x0f2Xc++SSAqExhg==", "62d8da1f-ec9b-435a-b382-0dca403f80e2" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cfcc5c95-4666-4fe1-b26a-50c4016dac21", 0, "28c0e8d4-75e5-4754-b881-9ace5d7ff3f6", "UniverseUser", "yoda@mail.com", false, "Yoda", "Master", false, null, "YODA@MAIL.COM", "YODA@MAIL.COM", "AQAAAAIAAYagAAAAECBLQHwjIDFReJZtaAswgodAvQly4T7q1Q3wyus9WytceaLO6y+A1m+Ox2Ji8f0RxQ==", null, false, "869d46a8-8c57-49c8-afcb-01e04a1028bd", false, "yoda@mail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6468123d-a641-4305-9a52-533361297ed3", "cfcc5c95-4666-4fe1-b26a-50c4016dac21" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6468123d-a641-4305-9a52-533361297ed3", "cfcc5c95-4666-4fe1-b26a-50c4016dac21" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6468123d-a641-4305-9a52-533361297ed3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfcc5c95-4666-4fe1-b26a-50c4016dac21");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "18990560-1cca-49b8-b4db-5adb987559c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4b721ba-3706-462f-8213-643a72b03eaf", "AQAAAAIAAYagAAAAEDzd0XgM3qDkIJlhjuVQTMkhsqhBEDIToxpTrBbRIQ1Ddm3+c3FV/Kj+TyutAUqZPw==", "45d68651-1b79-402f-b6ec-aa6d321109e3" });
        }
    }
}
