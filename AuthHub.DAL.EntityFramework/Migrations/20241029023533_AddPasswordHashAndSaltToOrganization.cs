using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordHashAndSaltToOrganization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "Passwords",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Organizations",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Organizations",
                type: "varbinary(max)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Passwords_OrganizationId",
                table: "Passwords",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passwords_Organizations_OrganizationId",
                table: "Passwords",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passwords_Organizations_OrganizationId",
                table: "Passwords");

            migrationBuilder.DropIndex(
                name: "IX_Passwords_OrganizationId",
                table: "Passwords");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Passwords");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Organizations");

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 10, 28, 0, 46, 45, 292, DateTimeKind.Utc).AddTicks(595), new DateTime(2024, 10, 28, 0, 46, 45, 292, DateTimeKind.Utc).AddTicks(596) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 10, 28, 0, 46, 45, 292, DateTimeKind.Utc).AddTicks(1225), new DateTime(2024, 10, 28, 0, 46, 45, 292, DateTimeKind.Utc).AddTicks(1227) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 10, 28, 0, 46, 45, 292, DateTimeKind.Utc).AddTicks(1230), new DateTime(2024, 10, 28, 0, 46, 45, 292, DateTimeKind.Utc).AddTicks(1231) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 10, 28, 0, 46, 45, 292, DateTimeKind.Utc).AddTicks(1233), new DateTime(2024, 10, 28, 0, 46, 45, 292, DateTimeKind.Utc).AddTicks(1234) });
        }
    }
}
