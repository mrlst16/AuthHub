﻿// <auto-generated />
using System;
using AuthHub.DAL.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AuthHub.DAL.EntityFramework.Migrations
{
    [DbContext(typeof(AuthHubContext))]
    [Migration("20241106051753_AddClaimsTemplates")]
    partial class AddClaimsTemplates
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuthHub.Models.Entities.Claims.ClaimsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClaimsKeyId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedUTC")
                        .HasColumnType("datetime2");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Claims");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Claims.ClaimsKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AuthSettingsId")
                        .HasColumnType("int");

                    b.Property<int?>("ClaimsTemplateId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DefaultValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedUTC")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthSettingsId");

                    b.HasIndex("ClaimsTemplateId");

                    b.ToTable("ClaimsKeys");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Claims.ClaimsTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedUTC")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("ClaimsTemplates");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Enums.AuthScheme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedUTC")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AuthSchemes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2024, 11, 6, 5, 17, 52, 237, DateTimeKind.Utc).AddTicks(1111),
                            LastUpdated = new DateTime(2024, 11, 6, 5, 17, 52, 237, DateTimeKind.Utc).AddTicks(1112),
                            Name = "JWT",
                            Value = 1
                        });
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Enums.VerificationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedUTC")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("VerificationTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2024, 11, 6, 5, 17, 52, 237, DateTimeKind.Utc).AddTicks(1816),
                            LastUpdated = new DateTime(2024, 11, 6, 5, 17, 52, 237, DateTimeKind.Utc).AddTicks(1817),
                            Name = "UserEmail",
                            Value = 0
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2024, 11, 6, 5, 17, 52, 237, DateTimeKind.Utc).AddTicks(1819),
                            LastUpdated = new DateTime(2024, 11, 6, 5, 17, 52, 237, DateTimeKind.Utc).AddTicks(1819),
                            Name = "PasswordReset",
                            Value = 1
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(2024, 11, 6, 5, 17, 52, 237, DateTimeKind.Utc).AddTicks(1820),
                            LastUpdated = new DateTime(2024, 11, 6, 5, 17, 52, 237, DateTimeKind.Utc).AddTicks(1821),
                            Name = "PhoneLogin",
                            Value = 2
                        });
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Organizations.APIKeyAndSecretHash", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedUTC")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Hash")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Iterations")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Salt")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("ApiKeyAndSecrets");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Organizations.AuthSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Audience")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AuthSchemeID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedUTC")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExpirationMinutes")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(30);

                    b.Property<int>("HashLength")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(8);

                    b.Property<string>("Issuer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Iterations")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(10);

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizationID")
                        .HasColumnType("int");

                    b.Property<string>("PasswordResetFormUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PasswordResetTokenExpirationMinutes")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(10);

                    b.Property<bool>("RequireVerification")
                        .HasColumnType("bit");

                    b.Property<int>("SaltLength")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(8);

                    b.HasKey("Id");

                    b.HasIndex("AuthSchemeID");

                    b.HasIndex("OrganizationID");

                    b.ToTable("AuthSettings");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Organizations.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedUTC")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Passwords.Password", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedUTC")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Passwords");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Passwords.PasswordArchive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedUTC")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Salt")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PasswordArchives");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Passwords.PasswordResetToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedUTC")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("VerificationCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PasswordResetToken");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Tokens.OrganizationToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedUTC")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId")
                        .IsUnique();

                    b.ToTable("OrganizationTokens");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Tokens.Token", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedUTC")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthSettingsId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedUTC")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthSettingsId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Verification.VerificationCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedUTC")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TypeId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("VerificationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.HasIndex("UserId");

                    b.ToTable("VerificationCodes");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Claims.ClaimsEntity", b =>
                {
                    b.HasOne("AuthHub.Models.Entities.Users.User", "User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Claims.ClaimsKey", b =>
                {
                    b.HasOne("AuthHub.Models.Entities.Organizations.AuthSettings", null)
                        .WithMany("AvailableClaimsKeys")
                        .HasForeignKey("AuthSettingsId");

                    b.HasOne("AuthHub.Models.Entities.Claims.ClaimsTemplate", "ClaimsTemplate")
                        .WithMany("ClaimsKeys")
                        .HasForeignKey("ClaimsTemplateId");

                    b.Navigation("ClaimsTemplate");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Claims.ClaimsTemplate", b =>
                {
                    b.HasOne("AuthHub.Models.Entities.Organizations.Organization", "Organization")
                        .WithMany("ClaimsTemplates")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Organizations.APIKeyAndSecretHash", b =>
                {
                    b.HasOne("AuthHub.Models.Entities.Organizations.Organization", null)
                        .WithMany("APIKeyAndSecretHash")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Organizations.AuthSettings", b =>
                {
                    b.HasOne("AuthHub.Models.Entities.Enums.AuthScheme", "AuthScheme")
                        .WithMany()
                        .HasForeignKey("AuthSchemeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuthHub.Models.Entities.Organizations.Organization", null)
                        .WithMany("Settings")
                        .HasForeignKey("OrganizationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuthScheme");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Passwords.Password", b =>
                {
                    b.HasOne("AuthHub.Models.Entities.Organizations.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId");

                    b.HasOne("AuthHub.Models.Entities.Users.User", null)
                        .WithOne("Password")
                        .HasForeignKey("AuthHub.Models.Entities.Passwords.Password", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Passwords.PasswordArchive", b =>
                {
                    b.HasOne("AuthHub.Models.Entities.Users.User", null)
                        .WithMany("PasswordArchives")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Passwords.PasswordResetToken", b =>
                {
                    b.HasOne("AuthHub.Models.Entities.Users.User", "User")
                        .WithMany("PasswordResetTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Tokens.OrganizationToken", b =>
                {
                    b.HasOne("AuthHub.Models.Entities.Organizations.Organization", "Organization")
                        .WithOne("Token")
                        .HasForeignKey("AuthHub.Models.Entities.Tokens.OrganizationToken", "OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Tokens.Token", b =>
                {
                    b.HasOne("AuthHub.Models.Entities.Users.User", "User")
                        .WithMany("Tokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Users.User", b =>
                {
                    b.HasOne("AuthHub.Models.Entities.Organizations.AuthSettings", "AuthSettings")
                        .WithMany("Users")
                        .HasForeignKey("AuthSettingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuthSettings");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Verification.VerificationCode", b =>
                {
                    b.HasOne("AuthHub.Models.Entities.Enums.VerificationType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");

                    b.HasOne("AuthHub.Models.Entities.Users.User", "User")
                        .WithMany("VerificationCodes")
                        .HasForeignKey("UserId");

                    b.Navigation("Type");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Claims.ClaimsTemplate", b =>
                {
                    b.Navigation("ClaimsKeys");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Organizations.AuthSettings", b =>
                {
                    b.Navigation("AvailableClaimsKeys");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Organizations.Organization", b =>
                {
                    b.Navigation("APIKeyAndSecretHash");

                    b.Navigation("ClaimsTemplates");

                    b.Navigation("Settings");

                    b.Navigation("Token");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Users.User", b =>
                {
                    b.Navigation("Claims");

                    b.Navigation("Password");

                    b.Navigation("PasswordArchives");

                    b.Navigation("PasswordResetTokens");

                    b.Navigation("Tokens");

                    b.Navigation("VerificationCodes");
                });
#pragma warning restore 612, 618
        }
    }
}
