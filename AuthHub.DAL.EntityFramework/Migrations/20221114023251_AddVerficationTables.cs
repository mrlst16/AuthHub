using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    public partial class AddVerficationTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VerificationTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUTC = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VerificationCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUTC = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificationCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VerificationCodes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VerificationCodes_VerificationTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "VerificationTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 14, 2, 32, 50, 234, DateTimeKind.Utc).AddTicks(696), new DateTime(2022, 11, 14, 2, 32, 50, 234, DateTimeKind.Utc).AddTicks(696) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 14, 2, 32, 50, 234, DateTimeKind.Utc).AddTicks(855), new DateTime(2022, 11, 14, 2, 32, 50, 234, DateTimeKind.Utc).AddTicks(856) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("6ce12da2-cb73-4f0b-b9f0-46051621b3c6"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 14, 2, 32, 50, 234, DateTimeKind.Utc).AddTicks(862), new DateTime(2022, 11, 14, 2, 32, 50, 234, DateTimeKind.Utc).AddTicks(862) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("6598c3ca-417e-47ed-b796-66f94af855df"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 14, 2, 32, 50, 234, DateTimeKind.Utc).AddTicks(1027), new DateTime(2022, 11, 14, 2, 32, 50, 234, DateTimeKind.Utc).AddTicks(1027) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("7ef019bd-4155-4c25-85d8-5eee7427af8a"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 14, 2, 32, 50, 234, DateTimeKind.Utc).AddTicks(1022), new DateTime(2022, 11, 14, 2, 32, 50, 234, DateTimeKind.Utc).AddTicks(1023) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("0b674ac4-7079-4ad7-830a-c41cd6ab5204"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 14, 2, 32, 50, 234, DateTimeKind.Utc).AddTicks(835), new DateTime(2022, 11, 14, 2, 32, 50, 234, DateTimeKind.Utc).AddTicks(836) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 14, 2, 32, 50, 234, DateTimeKind.Utc).AddTicks(830), new DateTime(2022, 11, 14, 2, 32, 50, 234, DateTimeKind.Utc).AddTicks(830) });

            migrationBuilder.UpdateData(
                table: "Passwords",
                keyColumn: "Id",
                keyValue: new Guid("8358a66e-b015-44a6-9cc3-7b5c2b9f1d79"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 14, 2, 32, 50, 234, DateTimeKind.Utc).AddTicks(1093), new DateTime(2022, 11, 14, 2, 32, 50, 234, DateTimeKind.Utc).AddTicks(1093) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b9e2e173-f8c4-41ed-be88-ec1071920130"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 14, 2, 32, 50, 234, DateTimeKind.Utc).AddTicks(1068), new DateTime(2022, 11, 14, 2, 32, 50, 234, DateTimeKind.Utc).AddTicks(1068) });

            migrationBuilder.InsertData(
                table: "VerificationTypes",
                columns: new[] { "Id", "CreateDate", "DeletedUTC", "LastUpdated", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("8eb05bdc-0f09-437b-af5a-06e5ff017556"), new DateTime(2022, 11, 14, 2, 32, 50, 234, DateTimeKind.Utc).AddTicks(1254), null, new DateTime(2022, 11, 14, 2, 32, 50, 234, DateTimeKind.Utc).AddTicks(1255), "PasswordReset", 1 },
                    { new Guid("b606fd56-6c9f-40ea-a274-1603d2ef9780"), new DateTime(2022, 11, 14, 2, 32, 50, 234, DateTimeKind.Utc).AddTicks(1251), null, new DateTime(2022, 11, 14, 2, 32, 50, 234, DateTimeKind.Utc).AddTicks(1252), "UserEmail", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VerificationCodes_TypeId",
                table: "VerificationCodes",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VerificationCodes_UserId",
                table: "VerificationCodes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VerificationCodes");

            migrationBuilder.DropTable(
                name: "VerificationTypes");

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(104), new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(106) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(501), new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(502) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("6ce12da2-cb73-4f0b-b9f0-46051621b3c6"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(515), new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(516) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("6598c3ca-417e-47ed-b796-66f94af855df"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(588), new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(589) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("7ef019bd-4155-4c25-85d8-5eee7427af8a"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(579), new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(580) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("0b674ac4-7079-4ad7-830a-c41cd6ab5204"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(433), new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(434) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(422), new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(423) });

            migrationBuilder.UpdateData(
                table: "Passwords",
                keyColumn: "Id",
                keyValue: new Guid("8358a66e-b015-44a6-9cc3-7b5c2b9f1d79"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(773), new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(774) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b9e2e173-f8c4-41ed-be88-ec1071920130"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(670), new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(671) });
        }
    }
}
