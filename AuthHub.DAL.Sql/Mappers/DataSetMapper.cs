﻿using AuthHub.Models.Enums;
using AuthHub.Models.Organizations;
using AuthHub.Models.Passwords;
using AuthHub.Models.Users;
using System.Data;

namespace AuthHub.DAL.Sql.Mappers
{
    public class DataSetMapper : IDataSetMapper
    {
        public Password MapPassword(DataTable table)
        {
            var result = new Password();
            if (table.HasDataForRow(0, out DataRow? row))
            {
                return new Password()
                {
                    Iterations = row.Field<int>("Iterations"),
                    HashLength = row.Field<int>("HasLength"),
                    PasswordHash = row.Field<byte[]>("PasswordHash"),
                    Salt = row.Field<byte[]>("Salt"),
                    UserName = row.Field<string>("UserName")
                };
            }
            return result;
        }

        public User MapUser(DataTable? table)
        {
            var result = new User();
            if (table?.HasDataForRow(0, out DataRow? row) ?? false)
            {
                result = new User()
                {
                    ID = row.Field<Guid>("ID"),
                    FirstName = row.Field<string>("FirstName"),
                    LastName = row.Field<string>("LastName"),
                    Email = row.Field<string>("Email"),
                    UserName = row.Field<string>("UserName")
                };
            }
            return result;
        }

        public List<SerializableClaim> MapClaims(DataTable? table)
        {
            List<SerializableClaim> result = new List<SerializableClaim>();
            if (table == null
                || table.Rows == null
                || table.Rows.Count == 0)
                return result;

            foreach (DataRow row in table.Rows)
            {
                var item = new SerializableClaim()
                {
                    Key = row.Field<string>("Key"),
                    Value = row.Field<string>("Value")
                };
                result.Add(item);
            }

            return result;
        }

        private List<ClaimEntity> MapClaimsEntities(DataTable table)
        {
            List<ClaimEntity> result = new List<ClaimEntity>();
            if (table == null
                || table.Rows == null
                || table.Rows.Count == 0)
                return result;

            foreach (DataRow row in table.Rows)
            {
                var item = new ClaimEntity()
                {
                    Id = row.Field<Guid>("Id"),
                    Key = row.Field<string>("Key"),
                    Value = row.Field<string>("Value"),
                    PasswordId = row.Field<Guid>("FK_Password")
                };
                result.Add(item);
            }

            return result;
        }

        public PasswordResetToken MapPasswordResetToken(DataTable? table)
        {
            PasswordResetToken result = new PasswordResetToken();

            if (table?.HasDataForRow(0, out DataRow? row) ?? false)
            {
                result = new PasswordResetToken()
                {
                    ID = row.Field<Guid>("ID"),
                    AuthSettingsName = row.Field<string>("AuthSettingsName"),
                    Email = row.Field<string>("Email"),
                    ExpirationDate = row.Field<DateTime>("ExpirationDate"),
                    IsActive = row.Field<bool>("IsActive"),
                    OrganizationID = row.Field<Guid>("OrganizationID"),
                    Salt = row.Field<byte[]>("Salt"),
                    Password = row.Field<byte[]>("Password"),
                    Token = row.Field<byte[]>("Token"),
                    UserName = row.Field<string>("UserName")
                };
            }
            return result;
        }

        public List<Organization> MapOrganizations(DataTable? table)
        {
            List<Organization> result = new();
            foreach (DataRow row in table.Rows)
            {
                Organization item = MapOrganization(row);
                result.Add(item);
            }
            return result;
        }

        public Organization MapOrganization(DataTable? table)
        {
            if (table?.HasDataForRow(0, out DataRow? row) ?? false)
            {
                return MapOrganization(row);
            }
            return new Organization();
        }

        public Organization MapOrganization(DataRow? row)
        {
            return new Organization()
            {
                ID = row.Field<Guid>("Id"),
                Name = row.Field<string>("Name"),
                Email = row.Field<string>("Email"),
            };
        }

        public AuthSettings MapAuthSettings(DataTable? table)
        {
            if (table?.HasDataForRow(0, out DataRow? row) ?? false)
            {
                return new AuthSettings()
                {
                    ID = row.Field<Guid>("Id"),
                    Name = row.Field<string>("Name"),
                    OrganizationID = row.Field<Guid>("OrganizationID"),
                    AuthScheme = row.Field<AuthSchemeEnum>("AuthScheme"),
                    ExpirationMinutes = row.Field<int>("AuthScheme"),
                    CreateDate = row.Field<DateTime>("CreateDate"),
                    LastUpdated = row.Field<DateTime>("LastUpdated"),
                    HashLength = row.Field<int>("HashLength"),
                    Issuer = row.Field<string>("Issuer"),
                    Iterations = row.Field<int>("Iterations"),
                    Key = row.Field<string>("Key"),
                    PasswordResetTokenExpirationMinutes = row.Field<int>("PasswordResetTokenExpirationMinutes"),
                    SaltLength = row.Field<int>("SaltLength")
                };
            }
            return new AuthSettings();
        }

        public Organization MapOrganization(DataSet? dataSet)
        {
            Organization result = new Organization();
            if (dataSet.HasDataForTable(0, out DataTable? organizationTable))
            {
                result = MapOrganization(organizationTable);
                if (dataSet.HasDataForTable(1, out DataTable? authSettingsTable))
                {
                    result.Settings = ToFlatAuthSettings(authSettingsTable);
                    List<Password> passwords = new List<Password>();
                    List<User> users = new List<User>();
                    List<ClaimEntity> claims = new List<ClaimEntity>();

                    if (dataSet.HasDataForTable(2, out DataTable? usersTable))
                        users = ToFlatUsers(usersTable);

                    if (dataSet.HasDataForTable(3, out DataTable? passwordsTable))
                        passwords = ToFlatPassword(passwordsTable);

                    if (dataSet.HasDataForTable(4, out DataTable? claimsTable))
                        claims = MapClaimsEntities(claimsTable);

                    foreach (AuthSettings setting in result.Settings)
                    {
                        setting.Users = users.Where(x => x.AuthSettingsId == setting.ID).ToList();
                        foreach (var user in setting.Users)
                        {
                            user.Password = passwords.First(x => x.UserId == setting.ID);
                            user.Password.Claims = claims
                                .Where(x => x.PasswordId == user.Password.ID)
                                .Select(x => new SerializableClaim()
                                {
                                    Key = x.Key,
                                    Value = x.Value
                                })
                                .ToList();
                        }
                    }
                }
            }
            return result;
        }

        private List<Password> ToFlatPassword(DataTable table)
        {
            List<Password> result = new List<Password>();
            foreach (DataRow row in table.Rows)
            {
                var item = new Password()
                {
                    Iterations = row.Field<int>("Iterations"),
                    HashLength = row.Field<int>("HasLength"),
                    PasswordHash = row.Field<byte[]>("PasswordHash"),
                    Salt = row.Field<byte[]>("Salt"),
                    UserName = row.Field<string>("UserName")
                };
                result.Add(item);
            }

            return result;
        }

        private List<AuthSettings> ToFlatAuthSettings(DataTable table)
        {
            List<AuthSettings> result = new List<AuthSettings>();
            foreach (DataRow row in table.Rows)
            {
                var item = new AuthSettings()
                {
                    ID = row.Field<Guid>("Id"),
                    Name = row.Field<string>("Name"),
                    OrganizationID = row.Field<Guid>("OrganizationID"),
                    AuthScheme = row.Field<AuthSchemeEnum>("AuthScheme"),
                    ExpirationMinutes = row.Field<int>("AuthScheme"),
                    CreateDate = row.Field<DateTime>("CreateDate"),
                    LastUpdated = row.Field<DateTime>("LastUpdated"),
                    HashLength = row.Field<int>("HashLength"),
                    Issuer = row.Field<string>("Issuer"),
                    Iterations = row.Field<int>("Iterations"),
                    Key = row.Field<string>("Key"),
                    PasswordResetTokenExpirationMinutes = row.Field<int>("PasswordResetTokenExpirationMinutes"),
                    SaltLength = row.Field<int>("SaltLength")
                };
                result.Add(item);
            }
            return result;
        }

        private List<User> ToFlatUsers(DataTable table)
        {
            List<User> result = new List<User>();
            foreach (DataRow row in table.Rows)
            {
                var item = new User()
                {
                    ID = row.Field<Guid>("Id"),
                    AuthSettingsId = row.Field<Guid>("FK_AuthSettings"),
                    UserName = row.Field<string>("UserName"),
                    Email = row.Field<string>("Email"),
                    FirstName = row.Field<string>("FirstName"),
                    LastName = row.Field<string>("LastName")
                };
                result.Add(item);
            }

            return result;
        }
    }

    internal struct ClaimEntity
    {
        public Guid Id { get; set; }
        public Guid PasswordId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}