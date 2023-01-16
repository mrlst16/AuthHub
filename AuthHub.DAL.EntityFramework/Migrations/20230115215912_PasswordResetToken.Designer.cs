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
    [Migration("20230115215912_PasswordResetToken")]
    partial class PasswordResetToken
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AuthHub.Models.Entities.Enums.AuthScheme", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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
                            Id = new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"),
                            CreateDate = new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2484),
                            LastUpdated = new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2485),
                            Name = "JWT",
                            Value = 1
                        });
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Enums.VerificationType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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
                            Id = new Guid("b606fd56-6c9f-40ea-a274-1603d2ef9780"),
                            CreateDate = new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2726),
                            LastUpdated = new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2726),
                            Name = "UserEmail",
                            Value = 0
                        },
                        new
                        {
                            Id = new Guid("8eb05bdc-0f09-437b-af5a-06e5ff017556"),
                            CreateDate = new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2728),
                            LastUpdated = new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2729),
                            Name = "PasswordReset",
                            Value = 1
                        });
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Organizations.APIKeyAndSecretHash", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Salt")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId")
                        .IsUnique();

                    b.ToTable("APIKeyAndSecretHash");

                    b.HasData(
                        new
                        {
                            Id = new Guid("68ab7350-9368-45ec-bd90-14bbe71480bd"),
                            CreateDate = new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2747),
                            Hash = new byte[] { 82, 173, 66, 213, 53, 147, 34, 195, 227, 190 },
                            Iterations = 10,
                            LastUpdated = new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2748),
                            Length = 10,
                            OrganizationId = new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"),
                            Salt = new byte[] { 142, 34, 0, 28 }
                        });
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Organizations.AuthSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Audience")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("AuthSchemeID")
                        .HasColumnType("uniqueidentifier");

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

                    b.Property<Guid>("OrganizationID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PasswordResetFormUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PasswordResetTokenExpirationMinutes")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(10);

                    b.Property<int>("SaltLength")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(8);

                    b.HasKey("Id");

                    b.HasIndex("AuthSchemeID");

                    b.HasIndex("OrganizationID");

                    b.ToTable("AuthSettings");

                    b.HasData(
                        new
                        {
                            Id = new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"),
                            Audience = "PawnderJWT",
                            AuthSchemeID = new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"),
                            CreateDate = new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2623),
                            ExpirationMinutes = 120,
                            HashLength = 8,
                            Issuer = "Pawnder",
                            Iterations = 10,
                            Key = "This is my auth key",
                            LastUpdated = new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2623),
                            Name = "Pawnder JWT",
                            OrganizationID = new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"),
                            PasswordResetTokenExpirationMinutes = 10,
                            SaltLength = 8
                        },
                        new
                        {
                            Id = new Guid("6ce12da2-cb73-4f0b-b9f0-46051621b3c6"),
                            AuthSchemeID = new Guid("2269d512-b2ec-47aa-82bd-ae68df0993f2"),
                            CreateDate = new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2629),
                            ExpirationMinutes = 120,
                            HashLength = 8,
                            Issuer = "Audder",
                            Iterations = 10,
                            Key = "This is my auth key",
                            LastUpdated = new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2629),
                            Name = "Audder_Clients",
                            OrganizationID = new Guid("0b674ac4-7079-4ad7-830a-c41cd6ab5204"),
                            PasswordResetTokenExpirationMinutes = 10,
                            SaltLength = 8
                        });
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Organizations.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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

                    b.HasKey("Id");

                    b.ToTable("Organizations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bcb980b4-b5b9-4bd6-9810-569dcd62feca"),
                            CreateDate = new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2603),
                            Email = "mattlantz88@gmail.com",
                            LastUpdated = new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2603),
                            Name = "Pawnder"
                        },
                        new
                        {
                            Id = new Guid("0b674ac4-7079-4ad7-830a-c41cd6ab5204"),
                            CreateDate = new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2608),
                            Email = "mattlantz88@gmail.com",
                            LastUpdated = new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2608),
                            Name = "Audder"
                        });
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Passwords.ClaimsEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClaimsKeyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedUTC")
                        .HasColumnType("datetime2");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PasswordId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PasswordId");

                    b.ToTable("Claims");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Passwords.ClaimsKey", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthSettingsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DefaultValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedUTC")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthSettingsId");

                    b.ToTable("ClaimsKeys");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7ef019bd-4155-4c25-85d8-5eee7427af8a"),
                            AuthSettingsId = new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"),
                            CreateDate = new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2650),
                            IsDefault = false,
                            LastUpdated = new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2651),
                            Name = "Name"
                        },
                        new
                        {
                            Id = new Guid("6598c3ca-417e-47ed-b796-66f94af855df"),
                            AuthSettingsId = new Guid("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"),
                            CreateDate = new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2654),
                            IsDefault = false,
                            LastUpdated = new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2655),
                            Name = "Role"
                        });
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Passwords.Password", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedUTC")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Passwords");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8358a66e-b015-44a6-9cc3-7b5c2b9f1d79"),
                            CreateDate = new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2668),
                            LastUpdated = new DateTime(2023, 1, 15, 21, 59, 11, 883, DateTimeKind.Utc).AddTicks(2669),
                            PasswordHash = new byte[] { 80, 97, 119, 110, 100, 101, 114, 50, 50, 33 },
                            Salt = new byte[] { 91, 156, 7, 89, 255, 32, 9, 14 },
                            UserId = new Guid("b9e2e173-f8c4-41ed-be88-ec1071920130")
                        });
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Passwords.PasswordArchive", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PasswordArchives");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Passwords.PasswordResetToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("VerificationCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PasswordResetToken");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Tokens.Token", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthSettingsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedUTC")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthSettingsId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Verification.VerificationCode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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

                    b.Property<Guid?>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("VerificationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.HasIndex("UserId");

                    b.ToTable("VerificationCodes");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Organizations.APIKeyAndSecretHash", b =>
                {
                    b.HasOne("AuthHub.Models.Entities.Organizations.Organization", null)
                        .WithOne("APIKeyAndSecretHash")
                        .HasForeignKey("AuthHub.Models.Entities.Organizations.APIKeyAndSecretHash", "OrganizationId")
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

            modelBuilder.Entity("AuthHub.Models.Entities.Passwords.ClaimsEntity", b =>
                {
                    b.HasOne("AuthHub.Models.Entities.Passwords.Password", null)
                        .WithMany("Claims")
                        .HasForeignKey("PasswordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Passwords.ClaimsKey", b =>
                {
                    b.HasOne("AuthHub.Models.Entities.Organizations.AuthSettings", null)
                        .WithMany("AvailableClaimsKeys")
                        .HasForeignKey("AuthSettingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Passwords.Password", b =>
                {
                    b.HasOne("AuthHub.Models.Entities.Users.User", null)
                        .WithOne("Password")
                        .HasForeignKey("AuthHub.Models.Entities.Passwords.Password", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("AuthHub.Models.Entities.Organizations.AuthSettings", b =>
                {
                    b.Navigation("AvailableClaimsKeys");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Organizations.Organization", b =>
                {
                    b.Navigation("APIKeyAndSecretHash");

                    b.Navigation("Settings");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Passwords.Password", b =>
                {
                    b.Navigation("Claims");
                });

            modelBuilder.Entity("AuthHub.Models.Entities.Users.User", b =>
                {
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
