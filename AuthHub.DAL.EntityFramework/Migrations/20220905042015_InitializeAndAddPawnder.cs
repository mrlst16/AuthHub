using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    public partial class InitializeAndAddPawnder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthScheme",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedUTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthScheme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedUTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PasswordResetToken",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedUTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordResetToken", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
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
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedUTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthSettings_AuthScheme_AuthSchemeID",
                        column: x => x.AuthSchemeID,
                        principalTable: "AuthScheme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthSettings_Organization_OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClaimsKey",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DefaultValue = table.Column<string>(type: "text", nullable: true),
                    AuthSettingsId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedUTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimsKey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimsKey_AuthSettings_AuthSettingsId",
                        column: x => x.AuthSettingsId,
                        principalTable: "AuthSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersOrganizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsOrganization = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    AuthSettingsId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedUTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_AuthSettings_AuthSettingsId",
                        column: x => x.AuthSettingsId,
                        principalTable: "AuthSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Password",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    Salt = table.Column<byte[]>(type: "bytea", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedUTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Password", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Password_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClaimsEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimsKeyId = table.Column<Guid>(type: "uuid", nullable: false),
                    PasswordId = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedUTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimsEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimsEntity_Password_PasswordId",
                        column: x => x.PasswordId,
                        principalTable: "Password",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AuthScheme",
                columns: new[] { "Id", "CreateDate", "DeletedUTC", "LastUpdated", "Name", "Value" },
                values: new object[] { new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"), new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(2781), null, new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(2781), "JWT", 1 });

            migrationBuilder.InsertData(
                table: "Organization",
                columns: new[] { "Id", "CreateDate", "DeletedUTC", "Email", "LastUpdated", "Name" },
                values: new object[,]
                {
                    { new Guid("0b674ac4-7079-4ad7-830a-c41cd6ab5204"), new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(2955), null, "mattlantz88@gmail.com", new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(2955), "Audder" },
                    { new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"), new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(2949), null, "mattlantz88@gmail.com", new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(2949), "Pawnder" }
                });

            migrationBuilder.InsertData(
                table: "AuthSettings",
                columns: new[] { "Id", "AuthSchemeID", "CreateDate", "DeletedUTC", "ExpirationMinutes", "HashLength", "Issuer", "Iterations", "Key", "LastUpdated", "Name", "OrganizationID", "PasswordResetTokenExpirationMinutes", "SaltLength" },
                values: new object[,]
                {
                    { new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"), new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"), new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(2972), null, 120, 8, "Pawnder", 10, "This is my auth key", new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(2973), "Pawnder JWT", new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"), 10, 8 },
                    { new Guid("6ce12da2-cb73-4f0b-b9f0-46051621b3c6"), new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"), new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(2987), null, 120, 8, "Audder", 10, "This is my auth key", new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(2987), "Audder_Clients", new Guid("0b674ac4-7079-4ad7-830a-c41cd6ab5204"), 10, 8 }
                });

            migrationBuilder.InsertData(
                table: "ClaimsKey",
                columns: new[] { "Id", "AuthSettingsId", "CreateDate", "DefaultValue", "DeletedUTC", "IsDefault", "LastUpdated", "Name" },
                values: new object[,]
                {
                    { new Guid("6598c3ca-417e-47ed-b796-66f94af855df"), new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"), new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(3011), null, null, false, new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(3011), "Role" },
                    { new Guid("7ef019bd-4155-4c25-85d8-5eee7427af8a"), new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"), new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(3006), null, null, false, new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(3006), "Name" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AuthSettingsId", "CreateDate", "DeletedUTC", "Email", "FirstName", "IsOrganization", "LastName", "LastUpdated", "UserName", "UsersOrganizationId" },
                values: new object[] { new Guid("b9e2e173-f8c4-41ed-be88-ec1071920130"), new Guid("6ce12da2-cb73-4f0b-b9f0-46051621b3c6"), new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(3029), null, "mattlantz88@gmail.com", "Pawnder", true, "Organization", new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(3029), "Pawnder", new Guid("0b674ac4-7079-4ad7-830a-c41cd6ab5204") });

            migrationBuilder.InsertData(
                table: "Password",
                columns: new[] { "Id", "CreateDate", "DeletedUTC", "ExpirationDate", "LastUpdated", "PasswordHash", "Salt", "UserId" },
                values: new object[] { new Guid("8358a66e-b015-44a6-9cc3-7b5c2b9f1d79"), new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(3046), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 5, 4, 20, 14, 901, DateTimeKind.Utc).AddTicks(3047), new byte[] { 80, 97, 119, 110, 100, 101, 114, 50, 50, 33 }, new byte[] { 91, 156, 7, 89, 255, 32, 9, 14 }, new Guid("b9e2e173-f8c4-41ed-be88-ec1071920130") });

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
