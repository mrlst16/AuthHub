using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AssociateUsersWithOrganizations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrganizationId_UserName",
                table: "Users",
                columns: new[] { "OrganizationId", "UserName" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Organizations_OrganizationId",
                table: "Users",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Organizations_OrganizationId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_OrganizationId_UserName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
    }
}
