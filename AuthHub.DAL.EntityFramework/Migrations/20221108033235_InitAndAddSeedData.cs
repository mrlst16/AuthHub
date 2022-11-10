using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    public partial class InitAndAddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthSchemes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUTC = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthSchemes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUTC = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PasswordResetToken",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerificationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUTC = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordResetToken", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersOrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsOrganization = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUTC = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthSchemeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SaltLength = table.Column<int>(type: "int", nullable: false, defaultValue: 8),
                    HashLength = table.Column<int>(type: "int", nullable: false, defaultValue: 8),
                    Iterations = table.Column<int>(type: "int", nullable: false, defaultValue: 10),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Issuer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirationMinutes = table.Column<int>(type: "int", nullable: false, defaultValue: 30),
                    PasswordResetTokenExpirationMinutes = table.Column<int>(type: "int", nullable: false, defaultValue: 10),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUTC = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthSettings_AuthSchemes_AuthSchemeID",
                        column: x => x.AuthSchemeID,
                        principalTable: "AuthSchemes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthSettings_Organizations_OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Passwords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUTC = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passwords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passwords_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthSettingsToUsersMap",
                columns: table => new
                {
                    AuthSettingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthSettingsToUsersMap", x => new { x.AuthSettingsId, x.UserId });
                    table.ForeignKey(
                        name: "FK_AuthSettingsToUsersMap_AuthSettings_AuthSettingsId",
                        column: x => x.AuthSettingsId,
                        principalTable: "AuthSettings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AuthSettingsToUsersMap_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClaimsKeys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthSettingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUTC = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimsKeys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimsKeys_AuthSettings_AuthSettingsId",
                        column: x => x.AuthSettingsId,
                        principalTable: "AuthSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimsKeyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PasswordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUTC = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Claims_Passwords_PasswordId",
                        column: x => x.PasswordId,
                        principalTable: "Passwords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AuthSchemes",
                columns: new[] { "Id", "CreateDate", "DeletedUTC", "LastUpdated", "Name", "Value" },
                values: new object[] { new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"), new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(104), null, new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(106), "JWT", 1 });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "CreateDate", "DeletedUTC", "Email", "LastUpdated", "Name" },
                values: new object[,]
                {
                    { new Guid("0b674ac4-7079-4ad7-830a-c41cd6ab5204"), new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(433), null, "mattlantz88@gmail.com", new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(434), "Audder" },
                    { new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"), new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(422), null, "mattlantz88@gmail.com", new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(423), "Pawnder" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "DeletedUTC", "Email", "FirstName", "IsOrganization", "LastName", "LastUpdated", "UserName", "UsersOrganizationId" },
                values: new object[] { new Guid("b9e2e173-f8c4-41ed-be88-ec1071920130"), new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(670), null, "mattlantz88@gmail.com", "Pawnder", true, "Organization", new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(671), "Pawnder", new Guid("0b674ac4-7079-4ad7-830a-c41cd6ab5204") });

            migrationBuilder.InsertData(
                table: "AuthSettings",
                columns: new[] { "Id", "AuthSchemeID", "CreateDate", "DeletedUTC", "ExpirationMinutes", "HashLength", "Issuer", "Iterations", "Key", "LastUpdated", "Name", "OrganizationID", "PasswordResetTokenExpirationMinutes", "SaltLength" },
                values: new object[] { new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"), new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"), new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(501), null, 120, 8, "Pawnder", 10, "This is my auth key", new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(502), "Pawnder JWT", new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"), 10, 8 });

            migrationBuilder.InsertData(
                table: "AuthSettings",
                columns: new[] { "Id", "AuthSchemeID", "CreateDate", "DeletedUTC", "ExpirationMinutes", "HashLength", "Issuer", "Iterations", "Key", "LastUpdated", "Name", "OrganizationID", "PasswordResetTokenExpirationMinutes", "SaltLength" },
                values: new object[] { new Guid("6ce12da2-cb73-4f0b-b9f0-46051621b3c6"), new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"), new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(515), null, 120, 8, "Audder", 10, "This is my auth key", new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(516), "Audder_Clients", new Guid("0b674ac4-7079-4ad7-830a-c41cd6ab5204"), 10, 8 });

            migrationBuilder.InsertData(
                table: "Passwords",
                columns: new[] { "Id", "CreateDate", "DeletedUTC", "ExpirationDate", "LastUpdated", "PasswordHash", "Salt", "UserId" },
                values: new object[] { new Guid("8358a66e-b015-44a6-9cc3-7b5c2b9f1d79"), new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(773), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(774), new byte[] { 80, 97, 119, 110, 100, 101, 114, 50, 50, 33 }, new byte[] { 91, 156, 7, 89, 255, 32, 9, 14 }, new Guid("b9e2e173-f8c4-41ed-be88-ec1071920130") });

            migrationBuilder.InsertData(
                table: "ClaimsKeys",
                columns: new[] { "Id", "AuthSettingsId", "CreateDate", "DefaultValue", "DeletedUTC", "IsDefault", "LastUpdated", "Name" },
                values: new object[] { new Guid("6598c3ca-417e-47ed-b796-66f94af855df"), new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"), new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(588), null, null, false, new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(589), "Role" });

            migrationBuilder.InsertData(
                table: "ClaimsKeys",
                columns: new[] { "Id", "AuthSettingsId", "CreateDate", "DefaultValue", "DeletedUTC", "IsDefault", "LastUpdated", "Name" },
                values: new object[] { new Guid("7ef019bd-4155-4c25-85d8-5eee7427af8a"), new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"), new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(579), null, null, false, new DateTime(2022, 11, 8, 3, 32, 34, 678, DateTimeKind.Utc).AddTicks(580), "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_AuthSettings_AuthSchemeID",
                table: "AuthSettings",
                column: "AuthSchemeID");

            migrationBuilder.CreateIndex(
                name: "IX_AuthSettings_OrganizationID",
                table: "AuthSettings",
                column: "OrganizationID");

            migrationBuilder.CreateIndex(
                name: "IX_AuthSettingsToUsersMap_UserId",
                table: "AuthSettingsToUsersMap",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_PasswordId",
                table: "Claims",
                column: "PasswordId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimsKeys_AuthSettingsId",
                table: "ClaimsKeys",
                column: "AuthSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Passwords_UserId",
                table: "Passwords",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthSettingsToUsersMap");

            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "ClaimsKeys");

            migrationBuilder.DropTable(
                name: "PasswordResetToken");

            migrationBuilder.DropTable(
                name: "Passwords");

            migrationBuilder.DropTable(
                name: "AuthSettings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AuthSchemes");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
