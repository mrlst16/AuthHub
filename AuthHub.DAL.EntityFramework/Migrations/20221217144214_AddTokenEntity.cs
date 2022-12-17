using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    public partial class AddTokenEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Token",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUTC = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Token_Users_UserId",
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
                values: new object[] { new DateTime(2022, 12, 17, 14, 42, 13, 868, DateTimeKind.Utc).AddTicks(8311), new DateTime(2022, 12, 17, 14, 42, 13, 868, DateTimeKind.Utc).AddTicks(8311) });

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 17, 14, 42, 13, 868, DateTimeKind.Utc).AddTicks(7295), new DateTime(2022, 12, 17, 14, 42, 13, 868, DateTimeKind.Utc).AddTicks(7296) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 17, 14, 42, 13, 868, DateTimeKind.Utc).AddTicks(7642), new DateTime(2022, 12, 17, 14, 42, 13, 868, DateTimeKind.Utc).AddTicks(7642) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("6ce12da2-cb73-4f0b-b9f0-46051621b3c6"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 17, 14, 42, 13, 868, DateTimeKind.Utc).AddTicks(7650), new DateTime(2022, 12, 17, 14, 42, 13, 868, DateTimeKind.Utc).AddTicks(7650) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("6598c3ca-417e-47ed-b796-66f94af855df"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 17, 14, 42, 13, 868, DateTimeKind.Utc).AddTicks(7687), new DateTime(2022, 12, 17, 14, 42, 13, 868, DateTimeKind.Utc).AddTicks(7687) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("7ef019bd-4155-4c25-85d8-5eee7427af8a"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 17, 14, 42, 13, 868, DateTimeKind.Utc).AddTicks(7680), new DateTime(2022, 12, 17, 14, 42, 13, 868, DateTimeKind.Utc).AddTicks(7681) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("0b674ac4-7079-4ad7-830a-c41cd6ab5204"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 17, 14, 42, 13, 868, DateTimeKind.Utc).AddTicks(7609), new DateTime(2022, 12, 17, 14, 42, 13, 868, DateTimeKind.Utc).AddTicks(7609) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 17, 14, 42, 13, 868, DateTimeKind.Utc).AddTicks(7604), new DateTime(2022, 12, 17, 14, 42, 13, 868, DateTimeKind.Utc).AddTicks(7604) });

            migrationBuilder.UpdateData(
                table: "Passwords",
                keyColumn: "Id",
                keyValue: new Guid("8358a66e-b015-44a6-9cc3-7b5c2b9f1d79"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 17, 14, 42, 13, 868, DateTimeKind.Utc).AddTicks(7757), new DateTime(2022, 12, 17, 14, 42, 13, 868, DateTimeKind.Utc).AddTicks(7758) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("8eb05bdc-0f09-437b-af5a-06e5ff017556"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 17, 14, 42, 13, 868, DateTimeKind.Utc).AddTicks(8290), new DateTime(2022, 12, 17, 14, 42, 13, 868, DateTimeKind.Utc).AddTicks(8291) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("b606fd56-6c9f-40ea-a274-1603d2ef9780"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 17, 14, 42, 13, 868, DateTimeKind.Utc).AddTicks(8285), new DateTime(2022, 12, 17, 14, 42, 13, 868, DateTimeKind.Utc).AddTicks(8287) });

            migrationBuilder.CreateIndex(
                name: "IX_Token_UserId",
                table: "Token",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.UpdateData(
                table: "APIKeyAndSecretHash",
                keyColumn: "Id",
                keyValue: new Guid("68ab7350-9368-45ec-bd90-14bbe71480bd"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 14, 3, 0, 8, 170, DateTimeKind.Utc).AddTicks(6742), new DateTime(2022, 12, 14, 3, 0, 8, 170, DateTimeKind.Utc).AddTicks(6742) });

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 14, 3, 0, 8, 170, DateTimeKind.Utc).AddTicks(6183), new DateTime(2022, 12, 14, 3, 0, 8, 170, DateTimeKind.Utc).AddTicks(6183) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 14, 3, 0, 8, 170, DateTimeKind.Utc).AddTicks(6601), new DateTime(2022, 12, 14, 3, 0, 8, 170, DateTimeKind.Utc).AddTicks(6601) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("6ce12da2-cb73-4f0b-b9f0-46051621b3c6"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 14, 3, 0, 8, 170, DateTimeKind.Utc).AddTicks(6615), new DateTime(2022, 12, 14, 3, 0, 8, 170, DateTimeKind.Utc).AddTicks(6615) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("6598c3ca-417e-47ed-b796-66f94af855df"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 14, 3, 0, 8, 170, DateTimeKind.Utc).AddTicks(6641), new DateTime(2022, 12, 14, 3, 0, 8, 170, DateTimeKind.Utc).AddTicks(6642) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("7ef019bd-4155-4c25-85d8-5eee7427af8a"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 14, 3, 0, 8, 170, DateTimeKind.Utc).AddTicks(6635), new DateTime(2022, 12, 14, 3, 0, 8, 170, DateTimeKind.Utc).AddTicks(6636) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("0b674ac4-7079-4ad7-830a-c41cd6ab5204"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 14, 3, 0, 8, 170, DateTimeKind.Utc).AddTicks(6576), new DateTime(2022, 12, 14, 3, 0, 8, 170, DateTimeKind.Utc).AddTicks(6576) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 14, 3, 0, 8, 170, DateTimeKind.Utc).AddTicks(6569), new DateTime(2022, 12, 14, 3, 0, 8, 170, DateTimeKind.Utc).AddTicks(6570) });

            migrationBuilder.UpdateData(
                table: "Passwords",
                keyColumn: "Id",
                keyValue: new Guid("8358a66e-b015-44a6-9cc3-7b5c2b9f1d79"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 14, 3, 0, 8, 170, DateTimeKind.Utc).AddTicks(6656), new DateTime(2022, 12, 14, 3, 0, 8, 170, DateTimeKind.Utc).AddTicks(6656) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("8eb05bdc-0f09-437b-af5a-06e5ff017556"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 14, 3, 0, 8, 170, DateTimeKind.Utc).AddTicks(6728), new DateTime(2022, 12, 14, 3, 0, 8, 170, DateTimeKind.Utc).AddTicks(6728) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("b606fd56-6c9f-40ea-a274-1603d2ef9780"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 14, 3, 0, 8, 170, DateTimeKind.Utc).AddTicks(6724), new DateTime(2022, 12, 14, 3, 0, 8, 170, DateTimeKind.Utc).AddTicks(6725) });
        }
    }
}
