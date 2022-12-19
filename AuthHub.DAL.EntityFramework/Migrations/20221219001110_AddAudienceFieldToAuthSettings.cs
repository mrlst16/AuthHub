using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    public partial class AddAudienceFieldToAuthSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Audience",
                table: "AuthSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "APIKeyAndSecretHash",
                keyColumn: "Id",
                keyValue: new Guid("68ab7350-9368-45ec-bd90-14bbe71480bd"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 0, 11, 10, 0, DateTimeKind.Utc).AddTicks(7584), new DateTime(2022, 12, 19, 0, 11, 10, 0, DateTimeKind.Utc).AddTicks(7585) });

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 0, 11, 10, 0, DateTimeKind.Utc).AddTicks(7242), new DateTime(2022, 12, 19, 0, 11, 10, 0, DateTimeKind.Utc).AddTicks(7243) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"),
                columns: new[] { "Audience", "CreateDate", "LastUpdated" },
                values: new object[] { "PawnderJWT", new DateTime(2022, 12, 19, 0, 11, 10, 0, DateTimeKind.Utc).AddTicks(7444), new DateTime(2022, 12, 19, 0, 11, 10, 0, DateTimeKind.Utc).AddTicks(7445) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("6ce12da2-cb73-4f0b-b9f0-46051621b3c6"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 0, 11, 10, 0, DateTimeKind.Utc).AddTicks(7452), new DateTime(2022, 12, 19, 0, 11, 10, 0, DateTimeKind.Utc).AddTicks(7452) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("6598c3ca-417e-47ed-b796-66f94af855df"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 0, 11, 10, 0, DateTimeKind.Utc).AddTicks(7477), new DateTime(2022, 12, 19, 0, 11, 10, 0, DateTimeKind.Utc).AddTicks(7478) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("7ef019bd-4155-4c25-85d8-5eee7427af8a"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 0, 11, 10, 0, DateTimeKind.Utc).AddTicks(7473), new DateTime(2022, 12, 19, 0, 11, 10, 0, DateTimeKind.Utc).AddTicks(7473) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("0b674ac4-7079-4ad7-830a-c41cd6ab5204"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 0, 11, 10, 0, DateTimeKind.Utc).AddTicks(7421), new DateTime(2022, 12, 19, 0, 11, 10, 0, DateTimeKind.Utc).AddTicks(7421) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 0, 11, 10, 0, DateTimeKind.Utc).AddTicks(7415), new DateTime(2022, 12, 19, 0, 11, 10, 0, DateTimeKind.Utc).AddTicks(7415) });

            migrationBuilder.UpdateData(
                table: "Passwords",
                keyColumn: "Id",
                keyValue: new Guid("8358a66e-b015-44a6-9cc3-7b5c2b9f1d79"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 0, 11, 10, 0, DateTimeKind.Utc).AddTicks(7495), new DateTime(2022, 12, 19, 0, 11, 10, 0, DateTimeKind.Utc).AddTicks(7496) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("8eb05bdc-0f09-437b-af5a-06e5ff017556"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 0, 11, 10, 0, DateTimeKind.Utc).AddTicks(7570), new DateTime(2022, 12, 19, 0, 11, 10, 0, DateTimeKind.Utc).AddTicks(7570) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("b606fd56-6c9f-40ea-a274-1603d2ef9780"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 0, 11, 10, 0, DateTimeKind.Utc).AddTicks(7567), new DateTime(2022, 12, 19, 0, 11, 10, 0, DateTimeKind.Utc).AddTicks(7568) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Audience",
                table: "AuthSettings");

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
        }
    }
}
