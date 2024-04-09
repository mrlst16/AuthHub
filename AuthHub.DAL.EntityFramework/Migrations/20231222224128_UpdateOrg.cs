using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    public partial class UpdateOrg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "Audience", "CreateDate", "Issuer", "LastUpdated", "Name" },
                values: new object[] { "HomeEcJWT", new DateTime(2023, 12, 22, 22, 41, 27, 426, DateTimeKind.Utc).AddTicks(8231), "HomeEc", new DateTime(2023, 12, 22, 22, 41, 27, 426, DateTimeKind.Utc).AddTicks(8231), "HomeEc JWT" });

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
                columns: new[] { "CreateDate", "LastUpdated", "Name" },
                values: new object[] { new DateTime(2023, 12, 22, 22, 41, 27, 426, DateTimeKind.Utc).AddTicks(7785), new DateTime(2023, 12, 22, 22, 41, 27, 426, DateTimeKind.Utc).AddTicks(7788), "HomeEc" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "APIKeyAndSecretHash",
                keyColumn: "Id",
                keyValue: new Guid("68ab7350-9368-45ec-bd90-14bbe71480bd"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1628), new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1629) });

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1357), new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1357) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"),
                columns: new[] { "Audience", "CreateDate", "Issuer", "LastUpdated", "Name" },
                values: new object[] { "PawnderJWT", new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1481), "Pawnder", new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1482), "Pawnder JWT" });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("6598c3ca-417e-47ed-b796-66f94af855df"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1563), new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1563) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("7ef019bd-4155-4c25-85d8-5eee7427af8a"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1547), new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1548) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"),
                columns: new[] { "CreateDate", "LastUpdated", "Name" },
                values: new object[] { new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1133), new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1136), "Pawnder" });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("8eb05bdc-0f09-437b-af5a-06e5ff017556"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1591), new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1591) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("b606fd56-6c9f-40ea-a274-1603d2ef9780"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1583), new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1583) });
        }
    }
}
