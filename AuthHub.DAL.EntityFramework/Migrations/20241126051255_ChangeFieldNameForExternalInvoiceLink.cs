using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFieldNameForExternalInvoiceLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExternalInvoiceLing",
                table: "Invoices",
                newName: "ExternalInvoiceLink");

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 26, 5, 12, 54, 650, DateTimeKind.Utc).AddTicks(8063), new DateTime(2024, 11, 26, 5, 12, 54, 650, DateTimeKind.Utc).AddTicks(8064) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 26, 5, 12, 54, 650, DateTimeKind.Utc).AddTicks(8298), new DateTime(2024, 11, 26, 5, 12, 54, 650, DateTimeKind.Utc).AddTicks(8298) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 26, 5, 12, 54, 650, DateTimeKind.Utc).AddTicks(8301), new DateTime(2024, 11, 26, 5, 12, 54, 650, DateTimeKind.Utc).AddTicks(8301) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 26, 5, 12, 54, 650, DateTimeKind.Utc).AddTicks(8302), new DateTime(2024, 11, 26, 5, 12, 54, 650, DateTimeKind.Utc).AddTicks(8303) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExternalInvoiceLink",
                table: "Invoices",
                newName: "ExternalInvoiceLing");

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 26, 5, 5, 17, 9, DateTimeKind.Utc).AddTicks(2148), new DateTime(2024, 11, 26, 5, 5, 17, 9, DateTimeKind.Utc).AddTicks(2148) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 26, 5, 5, 17, 9, DateTimeKind.Utc).AddTicks(2329), new DateTime(2024, 11, 26, 5, 5, 17, 9, DateTimeKind.Utc).AddTicks(2329) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 26, 5, 5, 17, 9, DateTimeKind.Utc).AddTicks(2334), new DateTime(2024, 11, 26, 5, 5, 17, 9, DateTimeKind.Utc).AddTicks(2334) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 26, 5, 5, 17, 9, DateTimeKind.Utc).AddTicks(2335), new DateTime(2024, 11, 26, 5, 5, 17, 9, DateTimeKind.Utc).AddTicks(2335) });
        }
    }
}
