using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordResetUrlToAuthSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordResetUrl",
                table: "AuthSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 23, 22, 0, 50, 377, DateTimeKind.Utc).AddTicks(8788), new DateTime(2024, 11, 23, 22, 0, 50, 377, DateTimeKind.Utc).AddTicks(8789) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 23, 22, 0, 50, 377, DateTimeKind.Utc).AddTicks(8944), new DateTime(2024, 11, 23, 22, 0, 50, 377, DateTimeKind.Utc).AddTicks(8944) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 23, 22, 0, 50, 377, DateTimeKind.Utc).AddTicks(8946), new DateTime(2024, 11, 23, 22, 0, 50, 377, DateTimeKind.Utc).AddTicks(8947) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 23, 22, 0, 50, 377, DateTimeKind.Utc).AddTicks(8948), new DateTime(2024, 11, 23, 22, 0, 50, 377, DateTimeKind.Utc).AddTicks(8948) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordResetUrl",
                table: "AuthSettings");

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 10, 21, 12, 14, 948, DateTimeKind.Utc).AddTicks(4114), new DateTime(2024, 11, 10, 21, 12, 14, 948, DateTimeKind.Utc).AddTicks(4115) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 10, 21, 12, 14, 948, DateTimeKind.Utc).AddTicks(4370), new DateTime(2024, 11, 10, 21, 12, 14, 948, DateTimeKind.Utc).AddTicks(4370) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 10, 21, 12, 14, 948, DateTimeKind.Utc).AddTicks(4373), new DateTime(2024, 11, 10, 21, 12, 14, 948, DateTimeKind.Utc).AddTicks(4373) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 10, 21, 12, 14, 948, DateTimeKind.Utc).AddTicks(4374), new DateTime(2024, 11, 10, 21, 12, 14, 948, DateTimeKind.Utc).AddTicks(4375) });
        }
    }
}
