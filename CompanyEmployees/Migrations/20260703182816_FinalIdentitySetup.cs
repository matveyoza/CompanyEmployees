using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyEmployees.Migrations
{
    /// <inheritdoc />
    public partial class FinalIdentitySetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "7ff07bbc-ed91-49dd-a88f-4d2f2c181962", null, "Manager", "MANAGER" },
                    { "cb89dd6e-d683-4165-8731-41a57bc28a9f", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ff07bbc-ed91-49dd-a88f-4d2f2c181962");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb89dd6e-d683-4165-8731-41a57bc28a9f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d93a592-f751-4a4f-adae-dc9ba7649bd4", null, "Administrator", "ADMINISTRATOR" },
                    { "55fb67fd-88c9-49c0-ad74-dba429e29727", null, "Manager", "MANAGER" }
                });
        }
    }
}
