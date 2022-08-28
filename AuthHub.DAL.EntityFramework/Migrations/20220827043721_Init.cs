using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthScheme",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    LastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletedUTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthScheme", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PasswordResetToken",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    LastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletedUTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordResetToken", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AuthSettings",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    OrganizationID = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthSchemeID = table.Column<Guid>(type: "uuid", nullable: false),
                    SaltLength = table.Column<int>(type: "integer", nullable: false, defaultValue: 8),
                    HashLength = table.Column<int>(type: "integer", nullable: false, defaultValue: 8),
                    Iterations = table.Column<int>(type: "integer", nullable: false, defaultValue: 10),
                    Key = table.Column<string>(type: "text", nullable: true),
                    Issuer = table.Column<string>(type: "text", nullable: true),
                    ExpirationMinutes = table.Column<int>(type: "integer", nullable: false, defaultValue: 30),
                    PasswordResetTokenExpirationMinutes = table.Column<int>(type: "integer", nullable: false, defaultValue: 10),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    LastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletedUTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthSettings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AuthSettings_AuthScheme_AuthSchemeID",
                        column: x => x.AuthSchemeID,
                        principalTable: "AuthScheme",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthSettings_Organization_OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "Organization",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClaimsKey",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AuthSettingsId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    LastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletedUTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimsKey", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClaimsKey_AuthSettings_AuthSettingsId",
                        column: x => x.AuthSettingsId,
                        principalTable: "AuthSettings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersOrganizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsOrganization = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    AuthSettingsId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    LastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletedUTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                    table.ForeignKey(
                        name: "FK_User_AuthSettings_AuthSettingsId",
                        column: x => x.AuthSettingsId,
                        principalTable: "AuthSettings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Password",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    Salt = table.Column<byte[]>(type: "bytea", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    LastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletedUTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Password", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Password_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClaimsEntity",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimsKeyId = table.Column<Guid>(type: "uuid", nullable: false),
                    PasswordId = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    LastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DeletedUTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimsEntity", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClaimsEntity_Password_PasswordId",
                        column: x => x.PasswordId,
                        principalTable: "Password",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AuthScheme",
                columns: new[] { "ID", "CreateDate", "DeletedUTC", "LastUpdated", "Name", "Value" },
                values: new object[] { new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"), new DateTime(2022, 8, 27, 4, 37, 20, 796, DateTimeKind.Utc).AddTicks(9758), null, new DateTime(2022, 8, 27, 4, 37, 20, 796, DateTimeKind.Utc).AddTicks(9758), "JWT", 1 });

            migrationBuilder.InsertData(
                table: "Organization",
                columns: new[] { "ID", "Email", "Name" },
                values: new object[] { new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"), "mattlantz88@gmail.com", "Pawnder" });

            migrationBuilder.InsertData(
                table: "AuthSettings",
                columns: new[] { "ID", "AuthSchemeID", "CreateDate", "DeletedUTC", "ExpirationMinutes", "HashLength", "Issuer", "Iterations", "Key", "LastUpdated", "Name", "OrganizationID", "PasswordResetTokenExpirationMinutes", "SaltLength" },
                values: new object[] { new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"), new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"), new DateTime(2022, 8, 27, 4, 37, 20, 796, DateTimeKind.Utc).AddTicks(9958), null, 120, 8, "Pawnder", 10, "This is my auth key", new DateTime(2022, 8, 27, 4, 37, 20, 796, DateTimeKind.Utc).AddTicks(9958), "Pawnder JWT", new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"), 10, 8 });

            migrationBuilder.InsertData(
                table: "ClaimsKey",
                columns: new[] { "ID", "AuthSettingsId", "CreateDate", "DeletedUTC", "LastUpdated", "Name" },
                values: new object[,]
                {
                    { new Guid("6598c3ca-417e-47ed-b796-66f94af855df"), new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"), new DateTime(2022, 8, 27, 4, 37, 20, 796, DateTimeKind.Utc).AddTicks(9988), null, new DateTime(2022, 8, 27, 4, 37, 20, 796, DateTimeKind.Utc).AddTicks(9989), "Name" },
                    { new Guid("7ef019bd-4155-4c25-85d8-5eee7427af8a"), new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"), new DateTime(2022, 8, 27, 4, 37, 20, 796, DateTimeKind.Utc).AddTicks(9983), null, new DateTime(2022, 8, 27, 4, 37, 20, 796, DateTimeKind.Utc).AddTicks(9983), "Name" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthSettings_AuthSchemeID",
                table: "AuthSettings",
                column: "AuthSchemeID");

            migrationBuilder.CreateIndex(
                name: "IX_AuthSettings_OrganizationID",
                table: "AuthSettings",
                column: "OrganizationID");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimsEntity_PasswordId",
                table: "ClaimsEntity",
                column: "PasswordId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimsKey_AuthSettingsId",
                table: "ClaimsKey",
                column: "AuthSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Password_UserId",
                table: "Password",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_AuthSettingsId",
                table: "User",
                column: "AuthSettingsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClaimsEntity");

            migrationBuilder.DropTable(
                name: "ClaimsKey");

            migrationBuilder.DropTable(
                name: "PasswordResetToken");

            migrationBuilder.DropTable(
                name: "Password");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "AuthSettings");

            migrationBuilder.DropTable(
                name: "AuthScheme");

            migrationBuilder.DropTable(
                name: "Organization");
        }
    }
}
