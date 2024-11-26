using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddInvoiceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDateUTC = table.Column<DateOnly>(type: "date", nullable: false),
                    DatePaidUTC = table.Column<DateOnly>(type: "date", nullable: true),
                    ExternalInvoiceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternalInvoiceLing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUTC = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_OrganizationId",
                table: "Invoices",
                column: "OrganizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.UpdateData(
                table: "AuthSchemes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 23, 22, 0, 50, 377, DateTimeKind.Utc).AddTicks(8788), new DateTime(2024, 11, 23, 22, 0, 50, 377, DateTimeKind.Utc).AddTicks(8789) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 23, 22, 0, 50, 377, DateTimeKind.Utc).AddTicks(8944), new DateTime(2024, 11, 23, 22, 0, 50, 377, DateTimeKind.Utc).AddTicks(8944) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 23, 22, 0, 50, 377, DateTimeKind.Utc).AddTicks(8946), new DateTime(2024, 11, 23, 22, 0, 50, 377, DateTimeKind.Utc).AddTicks(8947) });

            migrationBuilder.UpdateData(
                table: "VerificationTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "LastUpdated" },
                values: new object[] { new DateTime(2024, 11, 23, 22, 0, 50, 377, DateTimeKind.Utc).AddTicks(8948), new DateTime(2024, 11, 23, 22, 0, 50, 377, DateTimeKind.Utc).AddTicks(8948) });
        }
    }
}
