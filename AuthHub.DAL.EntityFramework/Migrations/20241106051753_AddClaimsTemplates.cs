using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddClaimsTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Claims_Passwords_PasswordId",
                table: "Claims");

            migrationBuilder.DropForeignKey(
                name: "FK_ClaimsKeys_AuthSettings_AuthSettingsId",
                table: "ClaimsKeys");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "ClaimsKeys");

            migrationBuilder.RenameColumn(
                name: "PasswordId",
                table: "Claims",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Claims_PasswordId",
                table: "Claims",
                newName: "IX_Claims_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Data",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AuthSettingsId",
                table: "ClaimsKeys",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ClaimsTemplateId",
                table: "ClaimsKeys",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClaimsTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUTC = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimsTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimsTemplates_Organizations_OrganizationId",
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
                name: "IX_ClaimsKeys_ClaimsTemplateId",
                table: "ClaimsKeys",
                column: "ClaimsTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimsTemplates_OrganizationId",
                table: "ClaimsTemplates",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Claims_Users_UserId",
                table: "Claims",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimsKeys_AuthSettings_AuthSettingsId",
                table: "ClaimsKeys",
                column: "AuthSettingsId",
                principalTable: "AuthSettings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimsKeys_ClaimsTemplates_ClaimsTemplateId",
                table: "ClaimsKeys",
                column: "ClaimsTemplateId",
                principalTable: "ClaimsTemplates",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Claims_Users_UserId",
                table: "Claims");

            migrationBuilder.DropForeignKey(
                name: "FK_ClaimsKeys_AuthSettings_AuthSettingsId",
                table: "ClaimsKeys");

            migrationBuilder.DropForeignKey(
                name: "FK_ClaimsKeys_ClaimsTemplates_ClaimsTemplateId",
                table: "ClaimsKeys");

            migrationBuilder.DropTable(
                name: "ClaimsTemplates");

            migrationBuilder.DropIndex(
                name: "IX_ClaimsKeys_ClaimsTemplateId",
                table: "ClaimsKeys");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ClaimsTemplateId",
                table: "ClaimsKeys");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Claims",
                newName: "PasswordId");

            migrationBuilder.RenameIndex(
                name: "IX_Claims_UserId",
                table: "Claims",
                newName: "IX_Claims_PasswordId");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "AuthSettingsId",
                table: "ClaimsKeys",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "ClaimsKeys",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Claims_Passwords_PasswordId",
                table: "Claims",
                column: "PasswordId",
                principalTable: "Passwords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimsKeys_AuthSettings_AuthSettingsId",
                table: "ClaimsKeys",
                column: "AuthSettingsId",
                principalTable: "AuthSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
