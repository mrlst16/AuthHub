using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    public partial class AddPawnderData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AuthSchemes",
                columns: new[] { "Id", "CreateDate", "DeletedUTC", "LastUpdated", "Name", "Value" },
                values: new object[] { new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"), new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1357), null, new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1357), "JWT", 1 });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "CreateDate", "DeletedUTC", "Email", "LastUpdated", "Name" },
                values: new object[] { new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"), new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1133), null, "mattlantz88@gmail.com", new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1136), "Pawnder" });

            migrationBuilder.InsertData(
                table: "VerificationTypes",
                columns: new[] { "Id", "CreateDate", "DeletedUTC", "LastUpdated", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("8eb05bdc-0f09-437b-af5a-06e5ff017556"), new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1591), null, new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1591), "PasswordReset", 1 },
                    { new Guid("b606fd56-6c9f-40ea-a274-1603d2ef9780"), new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1583), null, new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1583), "UserEmail", 0 }
                });

            migrationBuilder.InsertData(
                table: "APIKeyAndSecretHash",
                columns: new[] { "Id", "CreateDate", "DeletedUTC", "Hash", "Iterations", "LastUpdated", "Length", "OrganizationId", "Salt" },
                values: new object[] { new Guid("68ab7350-9368-45ec-bd90-14bbe71480bd"), new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1628), null, new byte[] { 82, 173, 66, 213, 53, 147, 34, 195, 227, 190 }, 10, new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1629), 10, new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"), new byte[] { 142, 34, 0, 28 } });

            migrationBuilder.InsertData(
                table: "AuthSettings",
                columns: new[] { "Id", "Audience", "AuthSchemeID", "CreateDate", "DeletedUTC", "ExpirationMinutes", "HashLength", "Issuer", "Iterations", "Key", "LastUpdated", "Name", "OrganizationID", "PasswordResetFormUrl", "PasswordResetTokenExpirationMinutes", "SaltLength" },
                values: new object[] { new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"), "PawnderJWT", new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"), new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1481), null, 120, 8, "Pawnder", 10, "This is my auth key", new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1482), "Pawnder JWT", new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"), null, 10, 8 });

            migrationBuilder.InsertData(
                table: "ClaimsKeys",
                columns: new[] { "Id", "AuthSettingsId", "CreateDate", "DefaultValue", "DeletedUTC", "IsDefault", "LastUpdated", "Name" },
                values: new object[] { new Guid("6598c3ca-417e-47ed-b796-66f94af855df"), new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"), new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1563), null, null, false, new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1563), "Role" });

            migrationBuilder.InsertData(
                table: "ClaimsKeys",
                columns: new[] { "Id", "AuthSettingsId", "CreateDate", "DefaultValue", "DeletedUTC", "IsDefault", "LastUpdated", "Name" },
                values: new object[] { new Guid("7ef019bd-4155-4c25-85d8-5eee7427af8a"), new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"), new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1547), null, null, false, new DateTime(2023, 2, 12, 17, 21, 57, 580, DateTimeKind.Utc).AddTicks(1548), "Name" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "APIKeyAndSecretHash",
                keyColumn: "Id",
                keyValue: new Guid("68ab7350-9368-45ec-bd90-14bbe71480bd"));

            migrationBuilder.DeleteData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("6598c3ca-417e-47ed-b796-66f94af855df"));

            migrationBuilder.DeleteData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("7ef019bd-4155-4c25-85d8-5eee7427af8a"));

            migrationBuilder.DeleteData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("8eb05bdc-0f09-437b-af5a-06e5ff017556"));

            migrationBuilder.DeleteData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("b606fd56-6c9f-40ea-a274-1603d2ef9780"));

            migrationBuilder.DeleteData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"));

            migrationBuilder.DeleteData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"));

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"));
        }
    }
}
