using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyEmployees.Migrations
{
    /// <inheritdoc />
    public partial class IdentitySetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7ad7a22-eb60-413c-a344-e52ea0b72008");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db5eeebb-c3bf-4585-b918-68ec6ec9e13f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d93a592-f751-4a4f-adae-dc9ba7649bd4", null, "Administrator", "ADMINISTRATOR" },
                    { "55fb67fd-88c9-49c0-ad74-dba429e29727", null, "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d93a592-f751-4a4f-adae-dc9ba7649bd4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55fb67fd-88c9-49c0-ad74-dba429e29727");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c7ad7a22-eb60-413c-a344-e52ea0b72008", null, "Administrator", "ADMINISTRATOR" },
                    { "db5eeebb-c3bf-4585-b918-68ec6ec9e13f", null, "Manager", "MANAGER" }
                });
        }
    }
}
