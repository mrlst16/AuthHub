using AuthHub.Models.Enums;
using AuthHub.Models.Organizations;
using AuthHub.Models.Passwords;
using AuthHub.Models.Requests;
using AuthHub.Models.Users;
using System.Data;

namespace AuthHub.DAL.Sql.Mappers
{
    public class DataSetMapper : IDataSetMapper
    {

        public T MapSingle<T>(DataSet? dataSet, string columnName = "Id")
            => MapSingle<T>(dataSet, 0, 0, columnName);

        public T MapSingle<T>(DataSet? dataSet, int tableIndex, int rowIndex, string columnName = "Id")
            => (dataSet?.HasDataForTable(tableIndex, out var table) ?? false)
                && (table?.HasDataForRow(rowIndex, out var row) ?? false)
                    ? (row.Field<T>(columnName) ?? default(T))
            : default(T);

        public Password MapPassword(DataTable table)
        {
            var result = new Password();
            if (table.HasDataForRow(0, out DataRow? row))
            {
                return new Password()
                {
                    UserId = row.Field<Guid>("FK_User"),
                    PasswordHash = row.Field<byte[]>("PasswordHash"),
                    Salt = row.Field<byte[]>("Salt"),
                };
            }
            return result;
        }

        public static LoginChallengeResponse MapLoginChallengeResponse(DataSet dataSet)
        {
            return null;
        }

        public User MapUser(DataSet? dataSet)
        {
            User result = new();
            if (dataSet == null) return result;

            if (dataSet.HasDataForTable(0, out var userTable))
            {
                result = MapUser(userTable);
                if (dataSet.HasDataForTable(1, out var passwordTable))
                {
                    result.Password ??= MapPassword(passwordTable);
                    if (dataSet.HasDataForTable(2, out var claimsTable))
                        result.Password.Claims = MapClaims(claimsTable);
                }
                result.UsersOrganizationId = MapSingle<Guid>(dataSet, 3, 0, "UsersOrganizationId");
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
                    AuthSettingsId = row.Field<Guid>("FK_AuthSettings"),
                    FirstName = row.Field<string>("FirstName"),
                    LastName = row.Field<string>("LastName"),
                    Email = row.Field<string>("Email"),
                    UserName = row.Field<string>("UserName")
                };
            }

            return result;
        }

        public List<Models.Passwords.ClaimsEntity> MapClaims(DataTable? table)
        {
            List<Models.Passwords.ClaimsEntity> result = new List<Models.Passwords.ClaimsEntity>();
            if (table == null
                || table.Rows == null
                || table.Rows.Count == 0)
                return result;

            foreach (DataRow row in table.Rows)
            {
                var item = new Models.Passwords.ClaimsEntity()
                {
                    Key = row.Field<string>("Name"),
                    Value = row.Field<string>("Value")
                };
                result.Add(item);
            }

            return result;
        }

        private List<ClaimsEntity> MapClaimsEntities(DataTable table)
        {
            List<ClaimsEntity> result = new List<ClaimsEntity>();
            if (table == null
                || table.Rows == null
                || table.Rows.Count == 0)
                return result;

            foreach (DataRow row in table.Rows)
            {
                var item = new ClaimsEntity()
                {
                    ID = row.Field<Guid>("Id"),
                    Key = row.Field<string>("Name"),
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
                    Email = row.Field<string>("Email"),
                    ExpirationDate = row.Field<DateTime>("ExpirationDate"),
                    Token = row.Field<string>("Token"),
                    UserId = row.Field<Guid>("FK_User")
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
                    OrganizationID = row.Field<Guid>("FK_Organization"),
                    AuthScheme = row.Field<AuthSchemeEnum>("AuthScheme"),
                    ExpirationMinutes = row.Field<int>("ExpirationMinutes"),
                    CreateDate = row.Field<DateTime>("CreatedUTC"),
                    LastUpdated = row.Field<DateTime>("ModifiedUTC"),
                    HashLength = row.Field<int>("HashLength"),
                    Issuer = row.Field<string>("Issuer"),
                    Iterations = row.Field<int>("Iterations"),
                    Key = row.Field<string>("AuthKey"),
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
                    List<ClaimsEntity> claims = new List<ClaimsEntity>();
                    List<ClaimsKey> claimsKeys = new List<ClaimsKey>();

                    if (dataSet.HasDataForTable(2, out DataTable? usersTable))
                        users = ToFlatUsers(usersTable);

                    if (dataSet.HasDataForTable(3, out DataTable? passwordsTable))
                        passwords = ToFlatPassword(passwordsTable);

                    if (dataSet.HasDataForTable(4, out DataTable? claimsTable))
                        claims = MapClaimsEntities(claimsTable);

                    if (dataSet.HasDataForTable(5, out DataTable? claimsKeysTable))
                        claimsKeys = MapClaimsKeys(claimsKeysTable);

                    foreach (AuthSettings setting in result.Settings)
                    {
                        setting.Users = users.Where(x => x.AuthSettingsId == setting.ID).ToList();
                        setting.AvailableClaimsKeys = claimsKeys.Where(x => x.AuthSettingsId == setting.ID).ToList();

                        foreach (var user in setting.Users)
                        {
                            user.Password = passwords.FirstOrDefault(x => x.UserId == user.ID);
                            if (user.Password == null) continue;
                            user.Password.Claims = claims
                                .Where(x => x.PasswordId == user.Password.ID)
                                .Select(x => new ClaimsEntity()
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
                    ID = row.Field<Guid>("Id"),
                    UserId = row.Field<Guid>("FK_User"),
                    PasswordHash = row.Field<byte[]>("PasswordHash"),
                    Salt = row.Field<byte[]>("Salt")
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
                    OrganizationID = row.Field<Guid>("FK_Organization"),
                    AuthScheme = row.Field<AuthSchemeEnum>("AuthScheme"),
                    ExpirationMinutes = row.Field<int>("ExpirationMinutes"),
                    CreateDate = row.Field<DateTime>("CreatedUTC"),
                    LastUpdated = row.Field<DateTime>("ModifiedUTC"),
                    HashLength = row.Field<int>("HashLength"),
                    Issuer = row.Field<string>("Issuer"),
                    Iterations = row.Field<int>("Iterations"),
                    Key = row.Field<string>("AuthKey"),
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

        public List<ClaimsKey> MapClaimsKeys(DataTable? table)
        {
            List<ClaimsKey> result = new List<ClaimsKey>();
            foreach (DataRow row in table.Rows)
            {
                var item = new ClaimsKey()
                {
                    ID = row.Field<Guid>("Id"),
                    AuthSettingsId = row.Field<Guid>("FK_AuthSettings"),
                    Name = row.Field<string>("Name")
                };
                result.Add(item);
            }
            return result;
        }

        public AuthSettings MapAuthSettings(DataSet? dataSet)
        {
            AuthSettings result = new AuthSettings();
            if (dataSet.HasDataForTable(0, out DataTable? authSettingsTable))
                result = MapAuthSettings(authSettingsTable);

            if (dataSet.HasDataForTable(1, out DataTable? usersTable))
            {
                var users = ToFlatUsers(usersTable);
                result.Users = users.Where(x => x.AuthSettingsId == result.ID);
            }

            return result;
        }
    }
}