using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddOrganizationToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrganizationTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUTC = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationTokens_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 10, 30, 4, 19, 21, 855, DateTimeKind.Utc).AddTicks(949), new DateTime(2024, 10, 30, 4, 19, 21, 855, DateTimeKind.Utc).AddTicks(950) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 10, 30, 4, 19, 21, 855, DateTimeKind.Utc).AddTicks(1167), new DateTime(2024, 10, 30, 4, 19, 21, 855, DateTimeKind.Utc).AddTicks(1168) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 10, 30, 4, 19, 21, 855, DateTimeKind.Utc).AddTicks(1171), new DateTime(2024, 10, 30, 4, 19, 21, 855, DateTimeKind.Utc).AddTicks(1171) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 10, 30, 4, 19, 21, 855, DateTimeKind.Utc).AddTicks(1172), new DateTime(2024, 10, 30, 4, 19, 21, 855, DateTimeKind.Utc).AddTicks(1173) });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationTokens_OrganizationId",
                table: "OrganizationTokens",
                column: "OrganizationId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizationTokens");

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 10, 29, 2, 35, 32, 72, DateTimeKind.Utc).AddTicks(4819), new DateTime(2024, 10, 29, 2, 35, 32, 72, DateTimeKind.Utc).AddTicks(4820) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 10, 29, 2, 35, 32, 72, DateTimeKind.Utc).AddTicks(5678), new DateTime(2024, 10, 29, 2, 35, 32, 72, DateTimeKind.Utc).AddTicks(5680) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 10, 29, 2, 35, 32, 72, DateTimeKind.Utc).AddTicks(5682), new DateTime(2024, 10, 29, 2, 35, 32, 72, DateTimeKind.Utc).AddTicks(5683) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 10, 29, 2, 35, 32, 72, DateTimeKind.Utc).AddTicks(5684), new DateTime(2024, 10, 29, 2, 35, 32, 72, DateTimeKind.Utc).AddTicks(5685) });
        }
    }
}
