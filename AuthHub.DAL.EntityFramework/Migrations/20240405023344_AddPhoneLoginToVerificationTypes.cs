using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    public partial class AddPhoneLoginToVerificationTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "APIKeyAndSecretHash",
                keyColumn: "Id",
                keyValue: new Guid("68ab7350-9368-45ec-bd90-14bbe71480bd"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 5, 2, 33, 43, 235, DateTimeKind.Utc).AddTicks(7530), new DateTime(2024, 4, 5, 2, 33, 43, 235, DateTimeKind.Utc).AddTicks(7530) });

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 5, 2, 33, 43, 235, DateTimeKind.Utc).AddTicks(7457), new DateTime(2024, 4, 5, 2, 33, 43, 235, DateTimeKind.Utc).AddTicks(7458) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 5, 2, 33, 43, 235, DateTimeKind.Utc).AddTicks(7477), new DateTime(2024, 4, 5, 2, 33, 43, 235, DateTimeKind.Utc).AddTicks(7477) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("6598c3ca-417e-47ed-b796-66f94af855df"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 5, 2, 33, 43, 235, DateTimeKind.Utc).AddTicks(7500), new DateTime(2024, 4, 5, 2, 33, 43, 235, DateTimeKind.Utc).AddTicks(7500) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("7ef019bd-4155-4c25-85d8-5eee7427af8a"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 5, 2, 33, 43, 235, DateTimeKind.Utc).AddTicks(7496), new DateTime(2024, 4, 5, 2, 33, 43, 235, DateTimeKind.Utc).AddTicks(7496) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 5, 2, 33, 43, 235, DateTimeKind.Utc).AddTicks(7232), new DateTime(2024, 4, 5, 2, 33, 43, 235, DateTimeKind.Utc).AddTicks(7250) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("8eb05bdc-0f09-437b-af5a-06e5ff017556"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 5, 2, 33, 43, 235, DateTimeKind.Utc).AddTicks(7515), new DateTime(2024, 4, 5, 2, 33, 43, 235, DateTimeKind.Utc).AddTicks(7516) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("b606fd56-6c9f-40ea-a274-1603d2ef9780"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 5, 2, 33, 43, 235, DateTimeKind.Utc).AddTicks(7513), new DateTime(2024, 4, 5, 2, 33, 43, 235, DateTimeKind.Utc).AddTicks(7513) });

            migrationBuilder.InsertData(
                table: "VerificationTypes",
                columns: new[] { "Id", "CreateDate", "DeletedUTC", "LastUpdated", "Name", "Value" },
                values: new object[] { new Guid("4df175eb-9255-49b9-8125-855dcffdd94e"), new DateTime(2024, 4, 5, 2, 33, 43, 235, DateTimeKind.Utc).AddTicks(7517), null, new DateTime(2024, 4, 5, 2, 33, 43, 235, DateTimeKind.Utc).AddTicks(7518), "PhoneLogin", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("4df175eb-9255-49b9-8125-855dcffdd94e"));

            migrationBuilder.UpdateData(
                table: "APIKeyAndSecretHash",
                keyColumn: "Id",
                keyValue: new Guid("68ab7350-9368-45ec-bd90-14bbe71480bd"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 5, 2, 23, 4, 611, DateTimeKind.Utc).AddTicks(3137), new DateTime(2024, 4, 5, 2, 23, 4, 611, DateTimeKind.Utc).AddTicks(3138) });

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 5, 2, 23, 4, 611, DateTimeKind.Utc).AddTicks(3065), new DateTime(2024, 4, 5, 2, 23, 4, 611, DateTimeKind.Utc).AddTicks(3065) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 5, 2, 23, 4, 611, DateTimeKind.Utc).AddTicks(3082), new DateTime(2024, 4, 5, 2, 23, 4, 611, DateTimeKind.Utc).AddTicks(3082) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("6598c3ca-417e-47ed-b796-66f94af855df"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 5, 2, 23, 4, 611, DateTimeKind.Utc).AddTicks(3106), new DateTime(2024, 4, 5, 2, 23, 4, 611, DateTimeKind.Utc).AddTicks(3106) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("7ef019bd-4155-4c25-85d8-5eee7427af8a"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 5, 2, 23, 4, 611, DateTimeKind.Utc).AddTicks(3102), new DateTime(2024, 4, 5, 2, 23, 4, 611, DateTimeKind.Utc).AddTicks(3103) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 5, 2, 23, 4, 611, DateTimeKind.Utc).AddTicks(2902), new DateTime(2024, 4, 5, 2, 23, 4, 611, DateTimeKind.Utc).AddTicks(2907) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("8eb05bdc-0f09-437b-af5a-06e5ff017556"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 5, 2, 23, 4, 611, DateTimeKind.Utc).AddTicks(3122), new DateTime(2024, 4, 5, 2, 23, 4, 611, DateTimeKind.Utc).AddTicks(3123) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("b606fd56-6c9f-40ea-a274-1603d2ef9780"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 5, 2, 23, 4, 611, DateTimeKind.Utc).AddTicks(3120), new DateTime(2024, 4, 5, 2, 23, 4, 611, DateTimeKind.Utc).AddTicks(3121) });
        }
    }
}
