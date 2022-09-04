﻿using AuthHub.Models.Enums;
using AuthHub.Models.Organizations;
using AuthHub.Models.Passwords;
using AuthHub.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AuthHub.DAL.EntityFramework
{
    public class AuthHubContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Organization> Organizations;
        public DbSet<AuthSettings> AuthSettings;
        public DbSet<User> Users;
        public DbSet<AuthScheme> AuthSchemes;
        public DbSet<Password> Passwords;
        public DbSet<ClaimsKey> ClaimsKeys;
        public DbSet<ClaimsEntity> Claims;
        public DbSet<PasswordResetToken> PasswordResetToken;

        public AuthHubContext()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public AuthHubContext(DbContextOptions<AuthHubContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetConnectionString("dopgsql");
            optionsBuilder.UseNpgsql(connectionString);
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
                .HasMany<AuthSettings>(x => x.Settings);
            modelBuilder.Entity<Organization>()
                .Property(x => x.Name)
                .IsRequired();
            modelBuilder.Entity<Organization>()
                .Property(x => x.Email)
                .IsRequired();

            //AuthSettings Setup
            modelBuilder.Entity<AuthSettings>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<AuthSettings>()
                .HasOne<AuthScheme>(x => x.AuthScheme);
            modelBuilder.Entity<AuthSettings>()
                .HasMany<ClaimsKey>(x => x.AvailableClaimsKeys);
            modelBuilder.Entity<AuthSettings>()
                .HasMany(x => x.Users);
            modelBuilder.Entity<AuthSettings>()
                .Property(x => x.ExpirationMinutes)
                .IsRequired()
                .HasDefaultValue(30);
            modelBuilder.Entity<AuthSettings>()
                .Property(x => x.HashLength)
                .IsRequired()
                .HasDefaultValue(8);
            modelBuilder.Entity<AuthSettings>()
                .Property(x => x.Iterations)
                .IsRequired()
                .HasDefaultValue(10);
            modelBuilder.Entity<AuthSettings>()
                .Property(x => x.Name)
                .IsRequired();
            modelBuilder.Entity<AuthSettings>()
                .Property(x => x.PasswordResetTokenExpirationMinutes)
                .IsRequired()
                .HasDefaultValue(10);
            modelBuilder.Entity<AuthSettings>()
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
                .Property(x => x.Token)
                .IsRequired();
            modelBuilder.Entity<PasswordResetToken>()
                .Property(x => x.UserId)
                .IsRequired();
            modelBuilder.Entity<PasswordResetToken>()
                .Property(x => x.ExpirationDate)
                .IsRequired();

            #endregion

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
                });

            modelBuilder.Entity<AuthSettings>()
                .HasData(new AuthSettings()
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
                        Name = "Name"
                    });
            #endregion
        }
    }
}