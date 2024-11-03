using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class MakeOrganizationHaveManyApiKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_APIKeyAndSecretHash_Organizations_OrganizationId",
                table: "APIKeyAndSecretHash");

            migrationBuilder.DropPrimaryKey(
                name: "PK_APIKeyAndSecretHash",
                table: "APIKeyAndSecretHash");

            migrationBuilder.DropIndex(
                name: "IX_APIKeyAndSecretHash_OrganizationId",
                table: "APIKeyAndSecretHash");

            migrationBuilder.RenameTable(
                name: "APIKeyAndSecretHash",
                newName: "ApiKeyAndSecrets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApiKeyAndSecrets",
                table: "ApiKeyAndSecrets",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 3, 6, 32, 18, 842, DateTimeKind.Utc).AddTicks(8652), new DateTime(2024, 11, 3, 6, 32, 18, 842, DateTimeKind.Utc).AddTicks(8653) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 3, 6, 32, 18, 842, DateTimeKind.Utc).AddTicks(8923), new DateTime(2024, 11, 3, 6, 32, 18, 842, DateTimeKind.Utc).AddTicks(8924) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 3, 6, 32, 18, 842, DateTimeKind.Utc).AddTicks(8926), new DateTime(2024, 11, 3, 6, 32, 18, 842, DateTimeKind.Utc).AddTicks(8927) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 3, 6, 32, 18, 842, DateTimeKind.Utc).AddTicks(8928), new DateTime(2024, 11, 3, 6, 32, 18, 842, DateTimeKind.Utc).AddTicks(8928) });

            migrationBuilder.CreateIndex(
                name: "IX_ApiKeyAndSecrets_OrganizationId",
                table: "ApiKeyAndSecrets",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApiKeyAndSecrets_Organizations_OrganizationId",
                table: "ApiKeyAndSecrets",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApiKeyAndSecrets_Organizations_OrganizationId",
                table: "ApiKeyAndSecrets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApiKeyAndSecrets",
                table: "ApiKeyAndSecrets");

            migrationBuilder.DropIndex(
                name: "IX_ApiKeyAndSecrets_OrganizationId",
                table: "ApiKeyAndSecrets");

            migrationBuilder.RenameTable(
                name: "ApiKeyAndSecrets",
                newName: "APIKeyAndSecretHash");

            migrationBuilder.AddPrimaryKey(
                name: "PK_APIKeyAndSecretHash",
                table: "APIKeyAndSecretHash",
                column: "Id");

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
                name: "IX_APIKeyAndSecretHash_OrganizationId",
                table: "APIKeyAndSecretHash",
                column: "OrganizationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_APIKeyAndSecretHash_Organizations_OrganizationId",
                table: "APIKeyAndSecretHash",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
