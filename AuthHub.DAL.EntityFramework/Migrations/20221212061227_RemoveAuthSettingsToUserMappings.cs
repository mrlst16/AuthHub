using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    public partial class RemoveAuthSettingsToUserMappings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthSettingsToUsersMap");

            migrationBuilder.UpdateData(
                table: "APIKeyAndSecretHash",
                keyColumn: "Id",
                keyValue: new Guid("68ab7350-9368-45ec-bd90-14bbe71480bd"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 12, 6, 12, 25, 707, DateTimeKind.Utc).AddTicks(8075), new DateTime(2022, 12, 12, 6, 12, 25, 707, DateTimeKind.Utc).AddTicks(8076) });

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 12, 6, 12, 25, 707, DateTimeKind.Utc).AddTicks(7466), new DateTime(2022, 12, 12, 6, 12, 25, 707, DateTimeKind.Utc).AddTicks(7467) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 12, 6, 12, 25, 707, DateTimeKind.Utc).AddTicks(7838), new DateTime(2022, 12, 12, 6, 12, 25, 707, DateTimeKind.Utc).AddTicks(7839) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("6ce12da2-cb73-4f0b-b9f0-46051621b3c6"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 12, 6, 12, 25, 707, DateTimeKind.Utc).AddTicks(7849), new DateTime(2022, 12, 12, 6, 12, 25, 707, DateTimeKind.Utc).AddTicks(7850) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("6598c3ca-417e-47ed-b796-66f94af855df"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 12, 6, 12, 25, 707, DateTimeKind.Utc).AddTicks(7888), new DateTime(2022, 12, 12, 6, 12, 25, 707, DateTimeKind.Utc).AddTicks(7889) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("7ef019bd-4155-4c25-85d8-5eee7427af8a"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 12, 6, 12, 25, 707, DateTimeKind.Utc).AddTicks(7881), new DateTime(2022, 12, 12, 6, 12, 25, 707, DateTimeKind.Utc).AddTicks(7882) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("0b674ac4-7079-4ad7-830a-c41cd6ab5204"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 12, 6, 12, 25, 707, DateTimeKind.Utc).AddTicks(7802), new DateTime(2022, 12, 12, 6, 12, 25, 707, DateTimeKind.Utc).AddTicks(7803) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 12, 6, 12, 25, 707, DateTimeKind.Utc).AddTicks(7794), new DateTime(2022, 12, 12, 6, 12, 25, 707, DateTimeKind.Utc).AddTicks(7795) });

            migrationBuilder.UpdateData(
                table: "Passwords",
                keyColumn: "Id",
                keyValue: new Guid("8358a66e-b015-44a6-9cc3-7b5c2b9f1d79"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 12, 6, 12, 25, 707, DateTimeKind.Utc).AddTicks(7954), new DateTime(2022, 12, 12, 6, 12, 25, 707, DateTimeKind.Utc).AddTicks(7955) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b9e2e173-f8c4-41ed-be88-ec1071920130"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 12, 6, 12, 25, 707, DateTimeKind.Utc).AddTicks(7923), new DateTime(2022, 12, 12, 6, 12, 25, 707, DateTimeKind.Utc).AddTicks(7924) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("8eb05bdc-0f09-437b-af5a-06e5ff017556"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 12, 6, 12, 25, 707, DateTimeKind.Utc).AddTicks(8049), new DateTime(2022, 12, 12, 6, 12, 25, 707, DateTimeKind.Utc).AddTicks(8049) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("b606fd56-6c9f-40ea-a274-1603d2ef9780"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 12, 6, 12, 25, 707, DateTimeKind.Utc).AddTicks(8044), new DateTime(2022, 12, 12, 6, 12, 25, 707, DateTimeKind.Utc).AddTicks(8044) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthSettingsToUsersMap",
                columns: table => new
                {
                    AuthSettingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "APIKeyAndSecretHash",
                keyColumn: "Id",
                keyValue: new Guid("68ab7350-9368-45ec-bd90-14bbe71480bd"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 11, 2, 41, 16, 652, DateTimeKind.Utc).AddTicks(6451), new DateTime(2022, 12, 11, 2, 41, 16, 652, DateTimeKind.Utc).AddTicks(6452) });

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 11, 2, 41, 16, 652, DateTimeKind.Utc).AddTicks(5788), new DateTime(2022, 12, 11, 2, 41, 16, 652, DateTimeKind.Utc).AddTicks(5789) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 11, 2, 41, 16, 652, DateTimeKind.Utc).AddTicks(6047), new DateTime(2022, 12, 11, 2, 41, 16, 652, DateTimeKind.Utc).AddTicks(6048) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("6ce12da2-cb73-4f0b-b9f0-46051621b3c6"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 11, 2, 41, 16, 652, DateTimeKind.Utc).AddTicks(6059), new DateTime(2022, 12, 11, 2, 41, 16, 652, DateTimeKind.Utc).AddTicks(6059) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("6598c3ca-417e-47ed-b796-66f94af855df"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 11, 2, 41, 16, 652, DateTimeKind.Utc).AddTicks(6122), new DateTime(2022, 12, 11, 2, 41, 16, 652, DateTimeKind.Utc).AddTicks(6123) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("7ef019bd-4155-4c25-85d8-5eee7427af8a"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 11, 2, 41, 16, 652, DateTimeKind.Utc).AddTicks(6114), new DateTime(2022, 12, 11, 2, 41, 16, 652, DateTimeKind.Utc).AddTicks(6115) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("0b674ac4-7079-4ad7-830a-c41cd6ab5204"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 11, 2, 41, 16, 652, DateTimeKind.Utc).AddTicks(5999), new DateTime(2022, 12, 11, 2, 41, 16, 652, DateTimeKind.Utc).AddTicks(5999) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 11, 2, 41, 16, 652, DateTimeKind.Utc).AddTicks(5981), new DateTime(2022, 12, 11, 2, 41, 16, 652, DateTimeKind.Utc).AddTicks(5983) });

            migrationBuilder.UpdateData(
                table: "Passwords",
                keyColumn: "Id",
                keyValue: new Guid("8358a66e-b015-44a6-9cc3-7b5c2b9f1d79"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 11, 2, 41, 16, 652, DateTimeKind.Utc).AddTicks(6339), new DateTime(2022, 12, 11, 2, 41, 16, 652, DateTimeKind.Utc).AddTicks(6340) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b9e2e173-f8c4-41ed-be88-ec1071920130"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 11, 2, 41, 16, 652, DateTimeKind.Utc).AddTicks(6310), new DateTime(2022, 12, 11, 2, 41, 16, 652, DateTimeKind.Utc).AddTicks(6311) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("8eb05bdc-0f09-437b-af5a-06e5ff017556"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 11, 2, 41, 16, 652, DateTimeKind.Utc).AddTicks(6429), new DateTime(2022, 12, 11, 2, 41, 16, 652, DateTimeKind.Utc).AddTicks(6430) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("b606fd56-6c9f-40ea-a274-1603d2ef9780"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 11, 2, 41, 16, 652, DateTimeKind.Utc).AddTicks(6425), new DateTime(2022, 12, 11, 2, 41, 16, 652, DateTimeKind.Utc).AddTicks(6426) });

            migrationBuilder.CreateIndex(
                name: "IX_AuthSettingsToUsersMap_UserId",
                table: "AuthSettingsToUsersMap",
                column: "UserId");
        }
    }
}
