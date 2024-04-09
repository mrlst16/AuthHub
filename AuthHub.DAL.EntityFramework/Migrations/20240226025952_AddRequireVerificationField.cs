using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    public partial class AddRequireVerificationField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RequireVerification",
                table: "AuthSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "APIKeyAndSecretHash",
                keyColumn: "Id",
                keyValue: new Guid("68ab7350-9368-45ec-bd90-14bbe71480bd"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 2, 26, 2, 59, 52, 233, DateTimeKind.Utc).AddTicks(1056), new DateTime(2024, 2, 26, 2, 59, 52, 233, DateTimeKind.Utc).AddTicks(1057) });

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 2, 26, 2, 59, 52, 233, DateTimeKind.Utc).AddTicks(856), new DateTime(2024, 2, 26, 2, 59, 52, 233, DateTimeKind.Utc).AddTicks(857) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 2, 26, 2, 59, 52, 233, DateTimeKind.Utc).AddTicks(902), new DateTime(2024, 2, 26, 2, 59, 52, 233, DateTimeKind.Utc).AddTicks(903) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("6598c3ca-417e-47ed-b796-66f94af855df"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 2, 26, 2, 59, 52, 233, DateTimeKind.Utc).AddTicks(962), new DateTime(2024, 2, 26, 2, 59, 52, 233, DateTimeKind.Utc).AddTicks(963) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("7ef019bd-4155-4c25-85d8-5eee7427af8a"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 2, 26, 2, 59, 52, 233, DateTimeKind.Utc).AddTicks(953), new DateTime(2024, 2, 26, 2, 59, 52, 233, DateTimeKind.Utc).AddTicks(954) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 2, 26, 2, 59, 52, 233, DateTimeKind.Utc).AddTicks(611), new DateTime(2024, 2, 26, 2, 59, 52, 233, DateTimeKind.Utc).AddTicks(615) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("8eb05bdc-0f09-437b-af5a-06e5ff017556"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 2, 26, 2, 59, 52, 233, DateTimeKind.Utc).AddTicks(1013), new DateTime(2024, 2, 26, 2, 59, 52, 233, DateTimeKind.Utc).AddTicks(1014) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("b606fd56-6c9f-40ea-a274-1603d2ef9780"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 2, 26, 2, 59, 52, 233, DateTimeKind.Utc).AddTicks(1006), new DateTime(2024, 2, 26, 2, 59, 52, 233, DateTimeKind.Utc).AddTicks(1007) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequireVerification",
                table: "AuthSettings");

            migrationBuilder.UpdateData(
                table: "APIKeyAndSecretHash",
                keyColumn: "Id",
                keyValue: new Guid("68ab7350-9368-45ec-bd90-14bbe71480bd"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 12, 22, 22, 41, 27, 426, DateTimeKind.Utc).AddTicks(8418), new DateTime(2023, 12, 22, 22, 41, 27, 426, DateTimeKind.Utc).AddTicks(8419) });

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 12, 22, 22, 41, 27, 426, DateTimeKind.Utc).AddTicks(8144), new DateTime(2023, 12, 22, 22, 41, 27, 426, DateTimeKind.Utc).AddTicks(8145) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 12, 22, 22, 41, 27, 426, DateTimeKind.Utc).AddTicks(8231), new DateTime(2023, 12, 22, 22, 41, 27, 426, DateTimeKind.Utc).AddTicks(8231) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("6598c3ca-417e-47ed-b796-66f94af855df"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 12, 22, 22, 41, 27, 426, DateTimeKind.Utc).AddTicks(8273), new DateTime(2023, 12, 22, 22, 41, 27, 426, DateTimeKind.Utc).AddTicks(8273) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("7ef019bd-4155-4c25-85d8-5eee7427af8a"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 12, 22, 22, 41, 27, 426, DateTimeKind.Utc).AddTicks(8266), new DateTime(2023, 12, 22, 22, 41, 27, 426, DateTimeKind.Utc).AddTicks(8266) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 12, 22, 22, 41, 27, 426, DateTimeKind.Utc).AddTicks(7785), new DateTime(2023, 12, 22, 22, 41, 27, 426, DateTimeKind.Utc).AddTicks(7788) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("8eb05bdc-0f09-437b-af5a-06e5ff017556"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 12, 22, 22, 41, 27, 426, DateTimeKind.Utc).AddTicks(8390), new DateTime(2023, 12, 22, 22, 41, 27, 426, DateTimeKind.Utc).AddTicks(8390) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("b606fd56-6c9f-40ea-a274-1603d2ef9780"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 12, 22, 22, 41, 27, 426, DateTimeKind.Utc).AddTicks(8384), new DateTime(2023, 12, 22, 22, 41, 27, 426, DateTimeKind.Utc).AddTicks(8385) });
        }
    }
}
