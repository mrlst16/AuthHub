using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    public partial class PasswordResetToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "APIKeyAndSecretHash",
                keyColumn: "Id",
                keyValue: new Guid("68ab7350-9368-45ec-bd90-14bbe71480bd"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2747), new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2748) });

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2484), new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2485) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2623), new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2623) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("6ce12da2-cb73-4f0b-b9f0-46051621b3c6"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2629), new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2629) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("6598c3ca-417e-47ed-b796-66f94af855df"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2654), new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2655) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("7ef019bd-4155-4c25-85d8-5eee7427af8a"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2650), new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2651) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("0b674ac4-7079-4ad7-830a-c41cd6ab5204"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2608), new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2608) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2603), new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2603) });

            migrationBuilder.UpdateData(
                table: "Passwords",
                keyColumn: "Id",
                keyValue: new Guid("8358a66e-b015-44a6-9cc3-7b5c2b9f1d79"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2668), new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2669) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("8eb05bdc-0f09-437b-af5a-06e5ff017556"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2728), new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2729) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("b606fd56-6c9f-40ea-a274-1603d2ef9780"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2726), new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2726) });

            migrationBuilder.CreateIndex(
                name: "IX_PasswordResetToken_UserId",
                table: "PasswordResetToken",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PasswordResetToken_Users_UserId",
                table: "PasswordResetToken",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PasswordResetToken_Users_UserId",
                table: "PasswordResetToken");

            migrationBuilder.DropIndex(
                name: "IX_PasswordResetToken_UserId",
                table: "PasswordResetToken");

            migrationBuilder.UpdateData(
                table: "APIKeyAndSecretHash",
                keyColumn: "Id",
                keyValue: new Guid("68ab7350-9368-45ec-bd90-14bbe71480bd"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(3225), new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(3226) });

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(2714), new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(2715) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(2982), new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(2983) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("6ce12da2-cb73-4f0b-b9f0-46051621b3c6"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(3007), new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(3007) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("6598c3ca-417e-47ed-b796-66f94af855df"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(3056), new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(3057) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("7ef019bd-4155-4c25-85d8-5eee7427af8a"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(3046), new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(3047) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("0b674ac4-7079-4ad7-830a-c41cd6ab5204"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(2945), new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(2946) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(2935), new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(2937) });

            migrationBuilder.UpdateData(
                table: "Passwords",
                keyColumn: "Id",
                keyValue: new Guid("8358a66e-b015-44a6-9cc3-7b5c2b9f1d79"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(3091), new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(3092) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("8eb05bdc-0f09-437b-af5a-06e5ff017556"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(3196), new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(3197) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("b606fd56-6c9f-40ea-a274-1603d2ef9780"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(3190), new DateTime(2023, 1, 8, 1, 26, 29, 901, DateTimeKind.Utc).AddTicks(3191) });
        }
    }
}
