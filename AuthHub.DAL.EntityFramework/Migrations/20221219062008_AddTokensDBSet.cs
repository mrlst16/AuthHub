using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    public partial class AddTokensDBSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Token_Users_UserId",
                table: "Token");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Token",
                table: "Token");

            migrationBuilder.RenameTable(
                name: "Token",
                newName: "Tokens");

            migrationBuilder.RenameIndex(
                name: "IX_Token_UserId",
                table: "Tokens",
                newName: "IX_Tokens_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tokens",
                table: "Tokens",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "APIKeyAndSecretHash",
                keyColumn: "Id",
                keyValue: new Guid("68ab7350-9368-45ec-bd90-14bbe71480bd"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4704), new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4704) });

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4422), new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4423) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4579), new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4580) });

            migrationBuilder.UpdateData(
                table: "AuthSettings",
                keyColumn: "Id",
                keyValue: new Guid("6ce12da2-cb73-4f0b-b9f0-46051621b3c6"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4587), new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4587) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("6598c3ca-417e-47ed-b796-66f94af855df"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4609), new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4609) });

            migrationBuilder.UpdateData(
                table: "ClaimsKeys",
                keyColumn: "Id",
                keyValue: new Guid("7ef019bd-4155-4c25-85d8-5eee7427af8a"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4604), new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4604) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("0b674ac4-7079-4ad7-830a-c41cd6ab5204"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4563), new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4563) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4558), new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4559) });

            migrationBuilder.UpdateData(
                table: "Passwords",
                keyColumn: "Id",
                keyValue: new Guid("8358a66e-b015-44a6-9cc3-7b5c2b9f1d79"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4623), new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4624) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("8eb05bdc-0f09-437b-af5a-06e5ff017556"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4690), new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4691) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: new Guid("b606fd56-6c9f-40ea-a274-1603d2ef9780"),
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4687), new DateTime(2022, 12, 19, 6, 20, 7, 717, DateTimeKind.Utc).AddTicks(4687) });

            migrationBuilder.AddForeignKey(
                name: "FK_Tokens_Users_UserId",
                table: "Tokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tokens_Users_UserId",
                table: "Tokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tokens",
                table: "Tokens");

            migrationBuilder.RenameTable(
                name: "Tokens",
                newName: "Token");

            migrationBuilder.RenameIndex(
                name: "IX_Tokens_UserId",
                table: "Token",
                newName: "IX_Token_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Token",
                table: "Token",
                column: "Id");

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
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 19, 0, 11, 10, 0, DateTimeKind.Utc).AddTicks(7444), new DateTime(2022, 12, 19, 0, 11, 10, 0, DateTimeKind.Utc).AddTicks(7445) });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Token_Users_UserId",
                table: "Token",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
