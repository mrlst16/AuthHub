using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAuthSettingsFromUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_AuthSettings_AuthSettingsId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AuthSettingsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AuthSettingsId",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 10, 7, 24, 40, 504, DateTimeKind.Utc).AddTicks(4141), new DateTime(2024, 11, 10, 7, 24, 40, 504, DateTimeKind.Utc).AddTicks(4142) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 10, 7, 24, 40, 504, DateTimeKind.Utc).AddTicks(4445), new DateTime(2024, 11, 10, 7, 24, 40, 504, DateTimeKind.Utc).AddTicks(4446) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 10, 7, 24, 40, 504, DateTimeKind.Utc).AddTicks(4451), new DateTime(2024, 11, 10, 7, 24, 40, 504, DateTimeKind.Utc).AddTicks(4451) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 10, 7, 24, 40, 504, DateTimeKind.Utc).AddTicks(4489), new DateTime(2024, 11, 10, 7, 24, 40, 504, DateTimeKind.Utc).AddTicks(4489) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthSettingsId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 10, 5, 51, 48, 39, DateTimeKind.Utc).AddTicks(4824), new DateTime(2024, 11, 10, 5, 51, 48, 39, DateTimeKind.Utc).AddTicks(4826) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 10, 5, 51, 48, 39, DateTimeKind.Utc).AddTicks(5045), new DateTime(2024, 11, 10, 5, 51, 48, 39, DateTimeKind.Utc).AddTicks(5046) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 10, 5, 51, 48, 39, DateTimeKind.Utc).AddTicks(5049), new DateTime(2024, 11, 10, 5, 51, 48, 39, DateTimeKind.Utc).AddTicks(5049) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 10, 5, 51, 48, 39, DateTimeKind.Utc).AddTicks(5050), new DateTime(2024, 11, 10, 5, 51, 48, 39, DateTimeKind.Utc).AddTicks(5051) });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AuthSettingsId",
                table: "Users",
                column: "AuthSettingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AuthSettings_AuthSettingsId",
                table: "Users",
                column: "AuthSettingsId",
                principalTable: "AuthSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
