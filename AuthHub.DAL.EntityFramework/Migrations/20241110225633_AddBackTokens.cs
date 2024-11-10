using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddBackTokens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Token_Users_UserId",
                table: "Token");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Token",
                table: "Token");

            migrationBuilder.RenameTable(
                name: "Token",
                newName: "Tokens");

            migrationBuilder.RenameIndex(
                name: "IX_Token_UserId",
                table: "Tokens",
                newName: "IX_Tokens_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tokens",
                table: "Tokens",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 10, 22, 56, 32, 369, DateTimeKind.Utc).AddTicks(141), new DateTime(2024, 11, 10, 22, 56, 32, 369, DateTimeKind.Utc).AddTicks(142) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 10, 22, 56, 32, 369, DateTimeKind.Utc).AddTicks(426), new DateTime(2024, 11, 10, 22, 56, 32, 369, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 10, 22, 56, 32, 369, DateTimeKind.Utc).AddTicks(428), new DateTime(2024, 11, 10, 22, 56, 32, 369, DateTimeKind.Utc).AddTicks(429) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 10, 22, 56, 32, 369, DateTimeKind.Utc).AddTicks(430), new DateTime(2024, 11, 10, 22, 56, 32, 369, DateTimeKind.Utc).AddTicks(430) });

            migrationBuilder.AddForeignKey(
                name: "FK_Tokens_Users_UserId",
                table: "Tokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tokens_Users_UserId",
                table: "Tokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tokens",
                table: "Tokens");

            migrationBuilder.RenameTable(
                name: "Tokens",
                newName: "Token");

            migrationBuilder.RenameIndex(
                name: "IX_Tokens_UserId",
                table: "Token",
                newName: "IX_Token_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Token",
                table: "Token",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 10, 22, 55, 31, 923, DateTimeKind.Utc).AddTicks(1186), new DateTime(2024, 11, 10, 22, 55, 31, 923, DateTimeKind.Utc).AddTicks(1187) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 10, 22, 55, 31, 923, DateTimeKind.Utc).AddTicks(1504), new DateTime(2024, 11, 10, 22, 55, 31, 923, DateTimeKind.Utc).AddTicks(1505) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 10, 22, 55, 31, 923, DateTimeKind.Utc).AddTicks(1507), new DateTime(2024, 11, 10, 22, 55, 31, 923, DateTimeKind.Utc).AddTicks(1507) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 10, 22, 55, 31, 923, DateTimeKind.Utc).AddTicks(1508), new DateTime(2024, 11, 10, 22, 55, 31, 923, DateTimeKind.Utc).AddTicks(1509) });

            migrationBuilder.AddForeignKey(
                name: "FK_Token_Users_UserId",
                table: "Token",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
