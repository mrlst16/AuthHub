﻿using AuthHub.BLL.Common.Helpers;
using AuthHub.Models.Enums;
using AuthHub.Models.Organizations;
using AuthHub.Models.Passwords;
using AuthHub.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using AuthSettingsModel = AuthHub.Models.Organizations.AuthSettings;

namespace AuthHub.DAL.EntityFramework
{
    public class AuthHubContext : DbContext
    {
        public DbSet<Organization> Organizations;
        public DbSet<AuthSettingsModel> AuthSettings;
        public DbSet<User> Users;
        public DbSet<AuthScheme> AuthSchemes;
        public DbSet<Password> Passwords;
        public DbSet<ClaimsKey> ClaimsKeys;
        public DbSet<ClaimsEntity> Claims;
        public DbSet<PasswordResetToken> PasswordResetToken;

        public AuthHubContext()
        {
        }

        public AuthHubContext(DbContextOptions<AuthHubContext> options)
        : base(options)
        {
        }

        protected IConfiguration GetConfigFromFile(string path = "appsettings.json")
            =>
                new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(path, optional: false, reloadOnChange: true)
                    .Build();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = GetConfigFromFile();
            string connectionString = configuration.GetConnectionString("authhub");
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Setup Schema
            //AuthScheme Setup
            modelBuilder.Entity<AuthScheme>()
                .HasKey(x => x.Id);

            //Organizations Setup
            modelBuilder.Entity<Organization>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Organization>()
                .HasMany<AuthSettingsModel>(x => x.Settings);
            modelBuilder.Entity<Organization>()
                .Property(x => x.Name)
                .IsRequired();
            modelBuilder.Entity<Organization>()
                .Property(x => x.Email)
                .IsRequired();

            //AuthSettings Setup
            modelBuilder.Entity<AuthSettingsModel>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<AuthSettingsModel>()
                .HasOne<AuthScheme>(x => x.AuthScheme);
            modelBuilder.Entity<AuthSettingsModel>()
                .HasMany<ClaimsKey>(x => x.AvailableClaimsKeys);
            modelBuilder.Entity<AuthSettingsModel>()
                .Property(x => x.ExpirationMinutes)
                .IsRequired()
                .HasDefaultValue(30);
            modelBuilder.Entity<AuthSettingsModel>()
                .Property(x => x.HashLength)
                .IsRequired()
                .HasDefaultValue(8);
            modelBuilder.Entity<AuthSettingsModel>()
                .Property(x => x.Iterations)
                .IsRequired()
                .HasDefaultValue(10);
            modelBuilder.Entity<AuthSettingsModel>()
                .Property(x => x.Name)
                .IsRequired();
            modelBuilder.Entity<AuthSettingsModel>()
                .Property(x => x.PasswordResetTokenExpirationMinutes)
                .IsRequired()
                .HasDefaultValue(10);
            modelBuilder.Entity<AuthSettingsModel>()
                .Property(x => x.SaltLength)
                .IsRequired()
                .HasDefaultValue(8);

            //Users Setup
            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<User>()
                .HasOne<Password>(x => x.Password);
            modelBuilder.Entity<User>()
                .Property(x => x.FirstName)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(x => x.LastName)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(x => x.UserName)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(x => x.IsOrganization)
                .IsRequired()
                .HasDefaultValue(false);
            modelBuilder.Entity<User>()
                .Property(x => x.Email)
                .IsRequired();

            //Passwords Setup
            modelBuilder.Entity<Password>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Password>()
                .HasMany<ClaimsEntity>(x => x.Claims);
            modelBuilder.Entity<Password>()
                .Property(x => x.PasswordHash)
                .IsRequired();
            modelBuilder.Entity<Password>()
                .Property(x => x.Salt)
                .IsRequired();
            modelBuilder.Entity<Password>()
                .Property(x => x.UserId)
                .IsRequired();
            modelBuilder.Entity<Password>()
                .Property(x => x.ExpirationDate)
                .IsRequired();

            //ClaimsKeys Setup
            modelBuilder.Entity<ClaimsKey>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<ClaimsKey>()
                .Property(x => x.AuthSettingsId)
                .IsRequired();
            modelBuilder.Entity<ClaimsKey>()
                .Property(x => x.Name)
                .IsRequired();

            //Claims Setup
            modelBuilder.Entity<ClaimsEntity>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<ClaimsEntity>()
                .Property(x => x.Key)
                .IsRequired();
            modelBuilder.Entity<ClaimsEntity>()
                .Property(x => x.ClaimsKeyId)
                .IsRequired();
            modelBuilder.Entity<ClaimsEntity>()
                .Property(x => x.PasswordId)
                .IsRequired();

            //PasswordResetToken Setup
            modelBuilder.Entity<PasswordResetToken>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<PasswordResetToken>()
                .Property(x => x.Email)
                .IsRequired();
            modelBuilder.Entity<PasswordResetToken>()
                .Property(x => x.VerificationCode)
                .IsRequired();
            modelBuilder.Entity<PasswordResetToken>()
                .Property(x => x.UserId)
                .IsRequired();
            modelBuilder.Entity<PasswordResetToken>()
                .Property(x => x.ExpirationDate)
                .IsRequired();
            #endregion

            modelBuilder.Entity<AuthSettingsModel>()
                .HasMany(p => p.Users)
                .WithMany(p => p.AuthSettings)
                .UsingEntity<Dictionary<string, object>>(
                    "AuthSettingsToUsersMap",
                    j => j
                        .HasOne<User>()
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_AuthSettingsToUsersMap_Users_UserId")
                        .OnDelete(DeleteBehavior.ClientNoAction),
                    j => j
                        .HasOne<AuthSettingsModel>()
                        .WithMany()
                        .HasForeignKey("AuthSettingsId")
                        .HasConstraintName("FK_AuthSettingsToUsersMap_AuthSettings_AuthSettingsId")
                        .OnDelete(DeleteBehavior.ClientNoAction));


            #region Load Data
            //Load Static data
            modelBuilder.Entity<AuthScheme>()
                .HasData(new AuthScheme()
                {
                    Id = Guid.Parse("2269d512-b2ec-47aa-82bd-ae68df0993f2"),
                    Name = "JWT",
                    Value = AuthSchemeEnum.JWT,
                    CreateDate = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow
                });

            //Load Client data
            modelBuilder.Entity<Organization>()
                .HasData(new Organization()
                {
                    Id = Guid.Parse("bcb980b4-b5b9-4bd6-9810-569dcd62feca"),
                    Name = "Pawnder",
                    Email = "mattlantz88@gmail.com"
                },
                new Organization()
                {
                    Id = Guid.Parse("0B674AC4-7079-4AD7-830A-C41CD6AB5204"),
                    Name = "Audder",
                    Email = "mattlantz88@gmail.com"
                });

            modelBuilder.Entity<AuthSettingsModel>()
                .HasData(new AuthSettingsModel()
                {
                    Id = Guid.Parse("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"),
                    OrganizationID = Guid.Parse("bcb980b4-b5b9-4bd6-9810-569dcd62feca"),
                    AuthSchemeID = Guid.Parse("2269d512-b2ec-47aa-82bd-ae68df0993f2"),
                    ExpirationMinutes = 120,
                    HashLength = 8,
                    Issuer = "Pawnder",
                    Iterations = 10,
                    Key = "This is my auth key",
                    Name = "Pawnder JWT",
                    PasswordResetTokenExpirationMinutes = 10,
                    SaltLength = 8
                },
                    new AuthSettingsModel()
                    {
                        Id = Guid.Parse("6CE12DA2-CB73-4F0B-B9F0-46051621B3C6"),
                        OrganizationID = Guid.Parse("0B674AC4-7079-4AD7-830A-C41CD6AB5204"),
                        AuthSchemeID = Guid.Parse("2269d512-b2ec-47aa-82bd-ae68df0993f2"),
                        ExpirationMinutes = 120,
                        HashLength = 8,
                        Issuer = "Audder",
                        Iterations = 10,
                        Key = "This is my auth key",
                        Name = "Audder_Clients",
                        PasswordResetTokenExpirationMinutes = 10,
                        SaltLength = 8
                    });

            modelBuilder.Entity<ClaimsKey>()
                .HasData(
                    new ClaimsKey()
                    {
                        Id = Guid.Parse("7ef019bd-4155-4c25-85d8-5eee7427af8a"),
                        AuthSettingsId = Guid.Parse("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"),
                        Name = "Name"
                    },
                    new ClaimsKey()
                    {
                        Id = Guid.Parse("6598c3ca-417e-47ed-b796-66f94af855df"),
                        AuthSettingsId = Guid.Parse("48f46ec0-a09e-4d76-a1d0-385c0c813b1f"),
                        Name = "Role"
                    });

            modelBuilder.Entity<User>()
                .HasData(new User()
                {
                    Id = Guid.Parse("b9e2e173-f8c4-41ed-be88-ec1071920130"),
                    IsOrganization = true,
                    UserName = "Pawnder",
                    Email = "mattlantz88@gmail.com",
                    UsersOrganizationId = Guid.Parse("0B674AC4-7079-4AD7-830A-C41CD6AB5204"),
                    FirstName = "Pawnder",
                    LastName = "Organization",
                    Password = null
                });

            modelBuilder.Entity<Password>()
                .HasData(new Password()
                {
                    Id = Guid.Parse("8358a66e-b015-44a6-9cc3-7b5c2b9f1d79"),
                    PasswordHash = ApplicationConsistency.GetBytesFromString("Pawnder22!"),
                    Salt = new byte[] { 91, 156, 7, 89, 255, 32, 9, 14 },
                    UserId = Guid.Parse("b9e2e173-f8c4-41ed-be88-ec1071920130"),
                    Claims = new List<ClaimsEntity>()
                });
        }
        #endregion
    }
}
