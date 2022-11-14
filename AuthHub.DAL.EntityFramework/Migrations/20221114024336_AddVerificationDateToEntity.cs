using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    public partial class AddVerificationDateToEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "VerificationDate",
                table: "VerificationCodes",
                type: "datetime2",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VerificationDate",
                table: "VerificationCodes");

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

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("8eb05bdc-0f09-437b-af5a-06e5ff017556"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 14, 2, 32, 50, 234, DateTimeKind.Utc).AddTicks(1254), new DateTime(2022, 11, 14, 2, 32, 50, 234, DateTimeKind.Utc).AddTicks(1255) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("b606fd56-6c9f-40ea-a274-1603d2ef9780"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 14, 2, 32, 50, 234, DateTimeKind.Utc).AddTicks(1251), new DateTime(2022, 11, 14, 2, 32, 50, 234, DateTimeKind.Utc).AddTicks(1252) });
        }
    }
}
