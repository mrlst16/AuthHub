using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    public partial class AddAPIKeyAndSecretHashforPawnder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APIKeyAndSecretHash",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Hash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Length = table.Column<int>(type: "int", nullable: false),
                    Iterations = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUTC = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APIKeyAndSecretHash", x => x.Id);
                    table.ForeignKey(
                        name: "FK_APIKeyAndSecretHash_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "APIKeyAndSecretHash",
                columns: new[] { "Id", "CreateDate", "DeletedUTC", "Hash", "Iterations", "LastUpdated", "Length", "OrganizationId", "Salt" },
                values: new object[] { new Guid("68ab7350-9368-45ec-bd90-14bbe71480bd"), new DateTime(2022, 12, 11, 2, 41, 16, 652, DateTimeKind.Utc).AddTicks(6451), null, new byte[] { 82, 173, 66, 213, 53, 147, 34, 195, 227, 190 }, 10, new DateTime(2022, 12, 11, 2, 41, 16, 652, DateTimeKind.Utc).AddTicks(6452), 10, new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"), new byte[] { 142, 34, 0, 28 } });

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
                name: "IX_APIKeyAndSecretHash_OrganizationId",
                table: "APIKeyAndSecretHash",
                column: "OrganizationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APIKeyAndSecretHash");

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 14, 2, 43, 35, 704, DateTimeKind.Utc).AddTicks(7178), new DateTime(2022, 11, 14, 2, 43, 35, 704, DateTimeKind.Utc).AddTicks(7179) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 14, 2, 43, 35, 704, DateTimeKind.Utc).AddTicks(7327), new DateTime(2022, 11, 14, 2, 43, 35, 704, DateTimeKind.Utc).AddTicks(7328) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("6ce12da2-cb73-4f0b-b9f0-46051621b3c6"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 14, 2, 43, 35, 704, DateTimeKind.Utc).AddTicks(7333), new DateTime(2022, 11, 14, 2, 43, 35, 704, DateTimeKind.Utc).AddTicks(7334) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("6598c3ca-417e-47ed-b796-66f94af855df"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 14, 2, 43, 35, 704, DateTimeKind.Utc).AddTicks(7358), new DateTime(2022, 11, 14, 2, 43, 35, 704, DateTimeKind.Utc).AddTicks(7358) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("7ef019bd-4155-4c25-85d8-5eee7427af8a"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 14, 2, 43, 35, 704, DateTimeKind.Utc).AddTicks(7351), new DateTime(2022, 11, 14, 2, 43, 35, 704, DateTimeKind.Utc).AddTicks(7352) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("0b674ac4-7079-4ad7-830a-c41cd6ab5204"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 14, 2, 43, 35, 704, DateTimeKind.Utc).AddTicks(7310), new DateTime(2022, 11, 14, 2, 43, 35, 704, DateTimeKind.Utc).AddTicks(7310) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 14, 2, 43, 35, 704, DateTimeKind.Utc).AddTicks(7306), new DateTime(2022, 11, 14, 2, 43, 35, 704, DateTimeKind.Utc).AddTicks(7306) });

            migrationBuilder.UpdateData(
                table: "Passwords",
                keyColumn: "Id",
                keyValue: new Guid("8358a66e-b015-44a6-9cc3-7b5c2b9f1d79"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 14, 2, 43, 35, 704, DateTimeKind.Utc).AddTicks(7399), new DateTime(2022, 11, 14, 2, 43, 35, 704, DateTimeKind.Utc).AddTicks(7399) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b9e2e173-f8c4-41ed-be88-ec1071920130"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 14, 2, 43, 35, 704, DateTimeKind.Utc).AddTicks(7380), new DateTime(2022, 11, 14, 2, 43, 35, 704, DateTimeKind.Utc).AddTicks(7380) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("8eb05bdc-0f09-437b-af5a-06e5ff017556"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 14, 2, 43, 35, 704, DateTimeKind.Utc).AddTicks(7466), new DateTime(2022, 11, 14, 2, 43, 35, 704, DateTimeKind.Utc).AddTicks(7466) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("b606fd56-6c9f-40ea-a274-1603d2ef9780"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 14, 2, 43, 35, 704, DateTimeKind.Utc).AddTicks(7463), new DateTime(2022, 11, 14, 2, 43, 35, 704, DateTimeKind.Utc).AddTicks(7464) });
        }
    }
}
