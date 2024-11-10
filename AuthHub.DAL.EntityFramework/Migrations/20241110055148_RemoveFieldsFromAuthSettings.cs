using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFieldsFromAuthSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClaimsKeys_AuthSettings_AuthSettingsId",
                table: "ClaimsKeys");

            migrationBuilder.DropIndex(
                name: "IX_ClaimsKeys_AuthSettingsId",
                table: "ClaimsKeys");

            migrationBuilder.DropColumn(
                name: "AuthSettingsId",
                table: "ClaimsKeys");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AuthSettings");

            migrationBuilder.DropColumn(
                name: "PasswordResetFormUrl",
                table: "AuthSettings");

            migrationBuilder.DropColumn(
                name: "PasswordResetTokenExpirationMinutes",
                table: "AuthSettings");

            migrationBuilder.DropColumn(
                name: "RequireVerification",
                table: "AuthSettings");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthSettingsId",
                table: "ClaimsKeys",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AuthSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PasswordResetFormUrl",
                table: "AuthSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PasswordResetTokenExpirationMinutes",
                table: "AuthSettings",
                type: "int",
                nullable: false,
                defaultValue: 10);

            migrationBuilder.AddColumn<bool>(
                name: "RequireVerification",
                table: "AuthSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                name: "IX_ClaimsKeys_AuthSettingsId",
                table: "ClaimsKeys",
                column: "AuthSettingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimsKeys_AuthSettings_AuthSettingsId",
                table: "ClaimsKeys",
                column: "AuthSettingsId",
                principalTable: "AuthSettings",
                principalColumn: "Id");
        }
    }
}
