using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniverseApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "18990560-1cca-49b8-b4db-5adb987559c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fb1fe78-9d9c-4a85-b3c7-bc2113be0d7d", "AQAAAAIAAYagAAAAEJ+S/ZZPooD4DIfK+lclg1rSCayvu7rbOM0mTBhkAPFN4PTosDwyAdqLYK9jbkDf4Q==", "8c7bf307-3541-4705-afce-de9606a3c869" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfcc5c95-4666-4fe1-b26a-50c4016dac21",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85b237f3-f542-402d-bc76-b0b72461390c", "AQAAAAIAAYagAAAAEPgEWHPEi3yV9qIjOBPBD4A7EDdfPkcudhv12bMfa0LbkPuWOs5N1OLl/qoQSJt5Pg==", "ca67e453-f597-4233-9b14-b045b42ed761" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "18990560-1cca-49b8-b4db-5adb987559c3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0b2f0ad-7828-4497-9995-8fbabf1117ae", "AQAAAAIAAYagAAAAEDIQ54JbNupgH7wiCfQtilz0N0SysuocdIVwMbFjO18dbtJckzm6DUEyWuRwL+TRmg==", "edf5205e-96f6-4a8c-988b-44f7b23c4600" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfcc5c95-4666-4fe1-b26a-50c4016dac21",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2667625-221b-4d6e-85e1-cab2540b1c02", "AQAAAAIAAYagAAAAEHjie/1AeYJLzjYl8A/okupp9mNwUcEJmB0uo5nUqgkklnSBXFanNbQewtqAFGVkWw==", "b5d6e149-6850-41e3-9bc0-a6c84ebe414e" });
        }
    }
}
