using AuthHub.DAL.EntityFramework.Models;
using AuthHub.Models.Enums;
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
        public DbSet<ClaimsEntity> Claims;
        public DbSet<PasswordResetToken> PasswordResetToken;

        public AuthHubContext()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
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
                .HasKey(x => x.ID);

            //Organizations Setup
            modelBuilder.Entity<Organization>()
                .HasKey(x => x.ID);
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
                .HasKey(x => x.ID);
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
                .HasKey(x => x.ID);
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
                .HasKey(x => x.ID);
            modelBuilder.Entity<Password>()
                .HasMany<ClaimsEntity>(x => x.Claims);

            #endregion

            #region Load Data
            //Load Static data
            modelBuilder.Entity<AuthScheme>()
                .HasData(AuthSchemeEnum.JWT);

            //Load Client data

            #endregion
        }
    }
}