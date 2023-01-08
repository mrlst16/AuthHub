using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    public partial class PasswordReset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_AuthSettings_AuthSettingsId1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AuthSettingsId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AuthSettingsId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "Passwords");

            migrationBuilder.AddColumn<string>(
                name: "PasswordResetFormUrl",
                table: "AuthSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PasswordArchives",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUTC = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordArchives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PasswordArchives_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "APIKeyAndSecretHash",
                keyColumn: "Id",
                keyValue: new Guid("68ab7350-9368-45ec-bd90-14bbe71480bd"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(3225), new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(3226) });

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(2714), new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(2715) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(2982), new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(2983) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("6ce12da2-cb73-4f0b-b9f0-46051621b3c6"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(3007), new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(3007) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("6598c3ca-417e-47ed-b796-66f94af855df"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(3056), new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(3057) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("7ef019bd-4155-4c25-85d8-5eee7427af8a"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(3046), new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(3047) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("0b674ac4-7079-4ad7-830a-c41cd6ab5204"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(2945), new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(2946) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(2935), new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(2937) });

            migrationBuilder.UpdateData(
                table: "Passwords",
                keyColumn: "Id",
                keyValue: new Guid("8358a66e-b015-44a6-9cc3-7b5c2b9f1d79"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(3091), new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(3092) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("8eb05bdc-0f09-437b-af5a-06e5ff017556"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(3196), new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(3197) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("b606fd56-6c9f-40ea-a274-1603d2ef9780"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(3190), new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(3191) });

            migrationBuilder.CreateIndex(
                name: "IX_PasswordArchives_UserId",
                table: "PasswordArchives",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PasswordArchives");

            migrationBuilder.DropColumn(
                name: "PasswordResetFormUrl",
                table: "AuthSettings");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthSettingsId1",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "Passwords",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "APIKeyAndSecretHash",
                keyColumn: "Id",
                keyValue: new Guid("68ab7350-9368-45ec-bd90-14bbe71480bd"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4704), new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4704) });

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4422), new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4423) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4579), new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4580) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("6ce12da2-cb73-4f0b-b9f0-46051621b3c6"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4587), new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4587) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("6598c3ca-417e-47ed-b796-66f94af855df"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4609), new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4609) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("7ef019bd-4155-4c25-85d8-5eee7427af8a"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4604), new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4604) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("0b674ac4-7079-4ad7-830a-c41cd6ab5204"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4563), new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4563) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4558), new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4559) });

            migrationBuilder.UpdateData(
                table: "Passwords",
                keyColumn: "Id",
                keyValue: new Guid("8358a66e-b015-44a6-9cc3-7b5c2b9f1d79"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4623), new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4624) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("8eb05bdc-0f09-437b-af5a-06e5ff017556"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4690), new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4691) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("b606fd56-6c9f-40ea-a274-1603d2ef9780"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4687), new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4687) });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AuthSettingsId1",
                table: "Users",
                column: "AuthSettingsId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AuthSettings_AuthSettingsId1",
                table: "Users",
                column: "AuthSettingsId1",
                principalTable: "AuthSettings",
                principalColumn: "Id");
        }
    }
}
