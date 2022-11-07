using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    public partial class ChangeUserAuthSettingsRelationshipToManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthSettingsId",
                table: "User");

            migrationBuilder.UpdateData(
                table: "AuthScheme",
                keyColumn: "Id",
                keyValue: new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 6, 19, 46, 26, 835, DateTimeKind.Utc).AddTicks(1307), new DateTime(2022, 11, 6, 19, 46, 26, 835, DateTimeKind.Utc).AddTicks(1308) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 6, 19, 46, 26, 835, DateTimeKind.Utc).AddTicks(1561), new DateTime(2022, 11, 6, 19, 46, 26, 835, DateTimeKind.Utc).AddTicks(1562) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("6ce12da2-cb73-4f0b-b9f0-46051621b3c6"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 6, 19, 46, 26, 835, DateTimeKind.Utc).AddTicks(1568), new DateTime(2022, 11, 6, 19, 46, 26, 835, DateTimeKind.Utc).AddTicks(1568) });

            migrationBuilder.UpdateData(
                table: "ClaimsKey",
                keyColumn: "Id",
                keyValue: new Guid("6598c3ca-417e-47ed-b796-66f94af855df"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 6, 19, 46, 26, 835, DateTimeKind.Utc).AddTicks(1599), new DateTime(2022, 11, 6, 19, 46, 26, 835, DateTimeKind.Utc).AddTicks(1599) });

            migrationBuilder.UpdateData(
                table: "ClaimsKey",
                keyColumn: "Id",
                keyValue: new Guid("7ef019bd-4155-4c25-85d8-5eee7427af8a"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 6, 19, 46, 26, 835, DateTimeKind.Utc).AddTicks(1594), new DateTime(2022, 11, 6, 19, 46, 26, 835, DateTimeKind.Utc).AddTicks(1594) });

            migrationBuilder.UpdateData(
                table: "Organization",
                keyColumn: "Id",
                keyValue: new Guid("0b674ac4-7079-4ad7-830a-c41cd6ab5204"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 6, 19, 46, 26, 835, DateTimeKind.Utc).AddTicks(1535), new DateTime(2022, 11, 6, 19, 46, 26, 835, DateTimeKind.Utc).AddTicks(1535) });

            migrationBuilder.UpdateData(
                table: "Organization",
                keyColumn: "Id",
                keyValue: new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 6, 19, 46, 26, 835, DateTimeKind.Utc).AddTicks(1529), new DateTime(2022, 11, 6, 19, 46, 26, 835, DateTimeKind.Utc).AddTicks(1530) });

            migrationBuilder.UpdateData(
                table: "Password",
                keyColumn: "Id",
                keyValue: new Guid("8358a66e-b015-44a6-9cc3-7b5c2b9f1d79"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 6, 19, 46, 26, 835, DateTimeKind.Utc).AddTicks(1658), new DateTime(2022, 11, 6, 19, 46, 26, 835, DateTimeKind.Utc).AddTicks(1659) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b9e2e173-f8c4-41ed-be88-ec1071920130"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 6, 19, 46, 26, 835, DateTimeKind.Utc).AddTicks(1618), new DateTime(2022, 11, 6, 19, 46, 26, 835, DateTimeKind.Utc).AddTicks(1618) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AuthSettingsId",
                table: "User",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AuthScheme",
                keyColumn: "Id",
                keyValue: new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3053), new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3054) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3241), new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3242) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("6ce12da2-cb73-4f0b-b9f0-46051621b3c6"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3248), new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3248) });

            migrationBuilder.UpdateData(
                table: "ClaimsKey",
                keyColumn: "Id",
                keyValue: new Guid("6598c3ca-417e-47ed-b796-66f94af855df"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3284), new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3285) });

            migrationBuilder.UpdateData(
                table: "ClaimsKey",
                keyColumn: "Id",
                keyValue: new Guid("7ef019bd-4155-4c25-85d8-5eee7427af8a"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3279), new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3280) });

            migrationBuilder.UpdateData(
                table: "Organization",
                keyColumn: "Id",
                keyValue: new Guid("0b674ac4-7079-4ad7-830a-c41cd6ab5204"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3212), new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3213) });

            migrationBuilder.UpdateData(
                table: "Organization",
                keyColumn: "Id",
                keyValue: new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3207), new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3208) });

            migrationBuilder.UpdateData(
                table: "Password",
                keyColumn: "Id",
                keyValue: new Guid("8358a66e-b015-44a6-9cc3-7b5c2b9f1d79"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3332), new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3333) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b9e2e173-f8c4-41ed-be88-ec1071920130"),
                columns: new[] { "AuthSettingsId", "CreateDate", "LastUpdated" },
                values: new object[] { new Guid("6ce12da2-cb73-4f0b-b9f0-46051621b3c6"), new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3310), new DateTime(2022, 11, 2, 1, 11, 13, 158, DateTimeKind.Utc).AddTicks(3311) });
        }
    }
}
