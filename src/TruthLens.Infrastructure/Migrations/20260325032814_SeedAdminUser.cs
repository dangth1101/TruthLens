using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruthLens.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: ["Id", "Username", "Password", "CreatedAt"],
                values: [
                    new Guid("00000000-0000-0000-0000-000000000001"),
                    "admin",
                    "changeme",
                    DateTime.UtcNow
                ]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));
        }
    }
}
