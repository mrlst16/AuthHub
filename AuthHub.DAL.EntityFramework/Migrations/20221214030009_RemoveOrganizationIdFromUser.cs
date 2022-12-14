using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    public partial class RemoveOrganizationIdFromUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b9e2e173-f8c4-41ed-be88-ec1071920130"));

            migrationBuilder.DropColumn(
                name: "IsOrganization",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UsersOrganizationId",
                table: "Users");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOrganization",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UsersOrganizationId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "APIKeyAndSecretHash",
                keyColumn: "Id",
                keyValue: new Guid("68ab7350-9368-45ec-bd90-14bbe71480bd"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 13, 4, 27, 16, 729, DateTimeKind.Utc).AddTicks(6257), new DateTime(2022, 12, 13, 4, 27, 16, 729, DateTimeKind.Utc).AddTicks(6258) });

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 13, 4, 27, 16, 729, DateTimeKind.Utc).AddTicks(5762), new DateTime(2022, 12, 13, 4, 27, 16, 729, DateTimeKind.Utc).AddTicks(5763) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 13, 4, 27, 16, 729, DateTimeKind.Utc).AddTicks(6047), new DateTime(2022, 12, 13, 4, 27, 16, 729, DateTimeKind.Utc).AddTicks(6048) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("6ce12da2-cb73-4f0b-b9f0-46051621b3c6"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 13, 4, 27, 16, 729, DateTimeKind.Utc).AddTicks(6057), new DateTime(2022, 12, 13, 4, 27, 16, 729, DateTimeKind.Utc).AddTicks(6057) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("6598c3ca-417e-47ed-b796-66f94af855df"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 13, 4, 27, 16, 729, DateTimeKind.Utc).AddTicks(6091), new DateTime(2022, 12, 13, 4, 27, 16, 729, DateTimeKind.Utc).AddTicks(6091) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("7ef019bd-4155-4c25-85d8-5eee7427af8a"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 13, 4, 27, 16, 729, DateTimeKind.Utc).AddTicks(6083), new DateTime(2022, 12, 13, 4, 27, 16, 729, DateTimeKind.Utc).AddTicks(6083) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("0b674ac4-7079-4ad7-830a-c41cd6ab5204"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 13, 4, 27, 16, 729, DateTimeKind.Utc).AddTicks(6016), new DateTime(2022, 12, 13, 4, 27, 16, 729, DateTimeKind.Utc).AddTicks(6017) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 13, 4, 27, 16, 729, DateTimeKind.Utc).AddTicks(6008), new DateTime(2022, 12, 13, 4, 27, 16, 729, DateTimeKind.Utc).AddTicks(6009) });

            migrationBuilder.UpdateData(
                table: "Passwords",
                keyColumn: "Id",
                keyValue: new Guid("8358a66e-b015-44a6-9cc3-7b5c2b9f1d79"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 13, 4, 27, 16, 729, DateTimeKind.Utc).AddTicks(6141), new DateTime(2022, 12, 13, 4, 27, 16, 729, DateTimeKind.Utc).AddTicks(6141) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthSettingsId", "AuthSettingsId1", "CreateDate", "DeletedUTC", "Email", "FirstName", "IsOrganization", "LastName", "LastUpdated", "UserName", "UsersOrganizationId" },
                values: new object[] { new Guid("b9e2e173-f8c4-41ed-be88-ec1071920130"), new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2022, 12, 13, 4, 27, 16, 729, DateTimeKind.Utc).AddTicks(6118), null, "mattlantz88@gmail.com", "Pawnder", true, "Organization", new DateTime(2022, 12, 13, 4, 27, 16, 729, DateTimeKind.Utc).AddTicks(6118), "Pawnder", new Guid("0b674ac4-7079-4ad7-830a-c41cd6ab5204") });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("8eb05bdc-0f09-437b-af5a-06e5ff017556"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 13, 4, 27, 16, 729, DateTimeKind.Utc).AddTicks(6234), new DateTime(2022, 12, 13, 4, 27, 16, 729, DateTimeKind.Utc).AddTicks(6235) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("b606fd56-6c9f-40ea-a274-1603d2ef9780"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 13, 4, 27, 16, 729, DateTimeKind.Utc).AddTicks(6231), new DateTime(2022, 12, 13, 4, 27, 16, 729, DateTimeKind.Utc).AddTicks(6231) });
        }
    }
}
