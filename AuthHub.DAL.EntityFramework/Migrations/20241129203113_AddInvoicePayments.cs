using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddInvoicePayments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatePaidUTC",
                table: "Invoices");

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUTC = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 29, 20, 31, 11, 851, DateTimeKind.Utc).AddTicks(1294), new DateTime(2024, 11, 29, 20, 31, 11, 851, DateTimeKind.Utc).AddTicks(1297) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 29, 20, 31, 11, 851, DateTimeKind.Utc).AddTicks(1805), new DateTime(2024, 11, 29, 20, 31, 11, 851, DateTimeKind.Utc).AddTicks(1806) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 29, 20, 31, 11, 851, DateTimeKind.Utc).AddTicks(1808), new DateTime(2024, 11, 29, 20, 31, 11, 851, DateTimeKind.Utc).AddTicks(1809) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 29, 20, 31, 11, 851, DateTimeKind.Utc).AddTicks(1810), new DateTime(2024, 11, 29, 20, 31, 11, 851, DateTimeKind.Utc).AddTicks(1811) });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_InvoiceId",
                table: "Payments",
                column: "InvoiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DatePaidUTC",
                table: "Invoices",
                type: "date",
                nullable: true);

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
    }
}
