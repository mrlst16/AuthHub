using AuthHub.Models.Entities.Enums;
using AuthHub.Models.Entities.Organizations;
using AuthHub.Models.Entities.Passwords;
using AuthHub.Models.Entities.Tokens;
using AuthHub.Models.Entities.Users;
using AuthHub.Models.Entities.Verification;
using AuthHub.Models.Enums;
using Microsoft.EntityFrameworkCore;

using AuthSettingsModel = AuthHub.Models.Entities.Organizations.AuthSettings;

namespace AuthHub.DAL.EntityFramework
{
    public class AuthHubContext : DbContext
    {
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<AuthSettingsModel> AuthSettings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AuthScheme> AuthSchemes { get; set; }
        public DbSet<Password> Passwords { get; set; }
        public DbSet<PasswordArchive> PasswordArchives { get; set; }
        public DbSet<ClaimsKey> ClaimsKeys { get; set; }
        public DbSet<ClaimsEntity> Claims { get; set; }
        public DbSet<PasswordResetToken> PasswordResetToken { get; set; }
        public DbSet<VerificationType> VerificationTypes { get; set; }
        public DbSet<VerificationCode> VerificationCodes { get; set; }
        public DbSet<Token> Tokens { get; set; }

        public AuthHubContext()
        {
        }

        public AuthHubContext(DbContextOptions<AuthHubContext> options)
        : base(options)
        {
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
            modelBuilder.Entity<Organization>()
                .HasOne<APIKeyAndSecretHash>(x => x.APIKeyAndSecretHash);

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
            modelBuilder.Entity<AuthSettingsModel>()
                .HasMany(x => x.Users)
                .WithOne(x => x.AuthSettings)
                .HasForeignKey(x => x.AuthSettingsId);

            //Users Setup
            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<User>()
                .HasOne(x => x.Password);
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
                .Property(x => x.Email)
                .IsRequired();
            modelBuilder.Entity<User>()
                .HasMany<VerificationCode>(x => x.VerificationCodes)
                .WithOne(x => x.User);
            modelBuilder.Entity<User>()
                .HasMany<Token>(x => x.Tokens)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
            modelBuilder.Entity<User>()
                .HasMany(x => x.PasswordArchives);
            modelBuilder.Entity<User>()
                .HasMany(x => x.PasswordResetTokens)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

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

            //Verification
            modelBuilder.Entity<VerificationType>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<VerificationCode>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<VerificationCode>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<VerificationCode>()
                .HasOne(x => x.Type);

            modelBuilder.Entity<APIKeyAndSecretHash>()
                .HasKey(x => x.Id);

            #endregion

            #region Load Data
            modelBuilder.Entity<AuthScheme>()
                .HasData(new AuthScheme()
                {
                    Id = 1,
                    Name = "JWT",
                    Value = AuthSchemeEnum.JWT,
                    CreateDate = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow
                });

            modelBuilder.Entity<VerificationType>()
                .HasData(
                    new VerificationType()
                    {
                        Id = 1,
                        Name = "UserEmail",
                        Value = VerificationTypeEnum.UserEmail,
                    },
                    new VerificationType()
                    {
                        Id = 2,
                        Name = "PasswordReset",
                        Value = VerificationTypeEnum.PasswordReset
                    },
                    new VerificationType()
                    {
                        Id = 3,
                        Name = "PhoneLogin",
                        Value = VerificationTypeEnum.PhoneLogin
                    }
                );

        }
        #endregion
    }
}
