using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    public partial class CreateManyToManyAuthSettingsToUsersRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_AuthSettings_AuthSettingsId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_AuthSettingsId",
                table: "User");

            migrationBuilder.CreateTable(
                name: "AuthSettingsToUsersMap",
                columns: table => new
                {
                    AuthSettingsId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthSettingsToUsersMap", x => new { x.AuthSettingsId, x.UserId });
                    table.ForeignKey(
                        name: "FK_AuthSettingsToUsersMap_AuthSettings_AuthSettingsId",
                        column: x => x.AuthSettingsId,
                        principalTable: "AuthSettings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AuthSettingsToUsersMap_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AuthScheme",
                keyColumn: "Id",
                keyValue: new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3053), new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3054) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3241), new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3242) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("6ce12da2-cb73-4f0b-b9f0-46051621b3c6"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3248), new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3248) });

            migrationBuilder.UpdateData(
                table: "ClaimsKey",
                keyColumn: "Id",
                keyValue: new Guid("6598c3ca-417e-47ed-b796-66f94af855df"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3284), new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3285) });

            migrationBuilder.UpdateData(
                table: "ClaimsKey",
                keyColumn: "Id",
                keyValue: new Guid("7ef019bd-4155-4c25-85d8-5eee7427af8a"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3279), new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3280) });

            migrationBuilder.UpdateData(
                table: "Organization",
                keyColumn: "Id",
                keyValue: new Guid("0b674ac4-7079-4ad7-830a-c41cd6ab5204"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3212), new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3213) });

            migrationBuilder.UpdateData(
                table: "Organization",
                keyColumn: "Id",
                keyValue: new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3207), new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3208) });

            migrationBuilder.UpdateData(
                table: "Password",
                keyColumn: "Id",
                keyValue: new Guid("8358a66e-b015-44a6-9cc3-7b5c2b9f1d79"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3332), new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3333) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b9e2e173-f8c4-41ed-be88-ec1071920130"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3310), new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3311) });

            migrationBuilder.CreateIndex(
                name: "IX_AuthSettingsToUsersMap_UserId",
                table: "AuthSettingsToUsersMap",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthSettingsToUsersMap");

            migrationBuilder.UpdateData(
                table: "AuthScheme",
                keyColumn: "Id",
                keyValue: new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(2781), new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(2781) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(2972), new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(2973) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("6ce12da2-cb73-4f0b-b9f0-46051621b3c6"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(2987), new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(2987) });

            migrationBuilder.UpdateData(
                table: "ClaimsKey",
                keyColumn: "Id",
                keyValue: new Guid("6598c3ca-417e-47ed-b796-66f94af855df"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(3011), new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(3011) });

            migrationBuilder.UpdateData(
                table: "ClaimsKey",
                keyColumn: "Id",
                keyValue: new Guid("7ef019bd-4155-4c25-85d8-5eee7427af8a"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(3006), new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(3006) });

            migrationBuilder.UpdateData(
                table: "Organization",
                keyColumn: "Id",
                keyValue: new Guid("0b674ac4-7079-4ad7-830a-c41cd6ab5204"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(2955), new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(2955) });

            migrationBuilder.UpdateData(
                table: "Organization",
                keyColumn: "Id",
                keyValue: new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(2949), new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(2949) });

            migrationBuilder.UpdateData(
                table: "Password",
                keyColumn: "Id",
                keyValue: new Guid("8358a66e-b015-44a6-9cc3-7b5c2b9f1d79"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(3046), new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(3047) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b9e2e173-f8c4-41ed-be88-ec1071920130"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(3029), new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(3029) });

            migrationBuilder.CreateIndex(
                name: "IX_User_AuthSettingsId",
                table: "User",
                column: "AuthSettingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_AuthSettings_AuthSettingsId",
                table: "User",
                column: "AuthSettingsId",
                principalTable: "AuthSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
