using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class MoveAuthSettingsToAOneToOneRelationshipToOrganization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AuthSettings_OrganizationID",
                table: "AuthSettings");

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 9, 1, 16, 20, 521, DateTimeKind.Utc).AddTicks(5465), new DateTime(2024, 11, 9, 1, 16, 20, 521, DateTimeKind.Utc).AddTicks(5466) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 9, 1, 16, 20, 521, DateTimeKind.Utc).AddTicks(6224), new DateTime(2024, 11, 9, 1, 16, 20, 521, DateTimeKind.Utc).AddTicks(6225) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 9, 1, 16, 20, 521, DateTimeKind.Utc).AddTicks(6228), new DateTime(2024, 11, 9, 1, 16, 20, 521, DateTimeKind.Utc).AddTicks(6228) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 9, 1, 16, 20, 521, DateTimeKind.Utc).AddTicks(6230), new DateTime(2024, 11, 9, 1, 16, 20, 521, DateTimeKind.Utc).AddTicks(6231) });

            migrationBuilder.CreateIndex(
                name: "IX_AuthSettings_OrganizationID",
                table: "AuthSettings",
                column: "OrganizationID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AuthSettings_OrganizationID",
                table: "AuthSettings");

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 6, 5, 17, 52, 237, DateTimeKind.Utc).AddTicks(1111), new DateTime(2024, 11, 6, 5, 17, 52, 237, DateTimeKind.Utc).AddTicks(1112) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 6, 5, 17, 52, 237, DateTimeKind.Utc).AddTicks(1816), new DateTime(2024, 11, 6, 5, 17, 52, 237, DateTimeKind.Utc).AddTicks(1817) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 6, 5, 17, 52, 237, DateTimeKind.Utc).AddTicks(1819), new DateTime(2024, 11, 6, 5, 17, 52, 237, DateTimeKind.Utc).AddTicks(1819) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 6, 5, 17, 52, 237, DateTimeKind.Utc).AddTicks(1820), new DateTime(2024, 11, 6, 5, 17, 52, 237, DateTimeKind.Utc).AddTicks(1821) });

            migrationBuilder.CreateIndex(
                name: "IX_AuthSettings_OrganizationID",
                table: "AuthSettings",
                column: "OrganizationID");
        }
    }
}
