using AuthHub.Models.Organizations;
using AuthHub.Models.Passwords;
using AuthHub.Models.Users;
using System.Data;
using System.Data.SqlClient;

namespace AuthHub.DAL.Sql.Mappers
{
    public class UdtMapper : IUdtMapper
    {
        public SqlParameter MapUdPassword(Password password)
        {
            DataTable val = new();
            val.Columns.Add("Id", typeof(Guid));
            val.Columns.Add("FK_User", typeof(Guid));
            val.Columns.Add("UserName", typeof(string));
            val.Columns.Add("PasswordHash", typeof(byte[]));
            val.Columns.Add("Salt", typeof(byte[]));
            val.Columns.Add("HashLength", typeof(string));
            val.Columns.Add("Iterations", typeof(string));

            var row = val.NewRow();
            row["Id"] = password.ID;
            row["FK_User"] = password.UserId;
            row["UserName"] = password.UserName;
            row["PasswordHash"] = password.PasswordHash;
            row["Salt"] = password.Salt;
            row["HashLength"] = password.HashLength;
            row["Iterations"] = password.Iterations;

            val.Rows.Add(row);

            return new SqlParameter("@request", SqlDbType.Structured)
            {
                TypeName = "udt_Password",
                Value = val
            };
        }

        public SqlParameter MapUdPasswordResetToken(PasswordResetToken token)
        {
            DataTable val = new();
            val.Columns.Add("Id", typeof(Guid));
            val.Columns.Add("FK_User", typeof(Guid));
            val.Columns.Add("Email", typeof(string));
            val.Columns.Add("ExpirationDate", typeof(DateTime));
            val.Columns.Add("Token", typeof(string));

            var row = val.NewRow();
            row["Id"] = token.ID;
            row["FK_User"] = token.UserId;
            row["Email"] = token.Email;
            row["ExpirationDate"] = token.ExpirationDate;
            row["Token"] = token.Token;

            val.Rows.Add(row);

            return new SqlParameter("@request", SqlDbType.Structured)
            {
                TypeName = "udt_PasswordResetToken",
                Value = val
            };
        }

        public SqlParameter MapUdtAuthSettings(AuthSettings authSettings)
        {
            DataTable val = new();
            val.Columns.Add("Id", typeof(Guid));
            val.Columns.Add("FK_Organization", typeof(Guid));
            val.Columns.Add("Name", typeof(string));
            val.Columns.Add("AuthScheme", typeof(int));
            val.Columns.Add("SaltLength", typeof(string));
            val.Columns.Add("HashLength", typeof(int));
            val.Columns.Add("Iterations", typeof(int));
            val.Columns.Add("ExpirationMinutes", typeof(int));
            val.Columns.Add("AuthKey", typeof(string));
            val.Columns.Add("Issuer", typeof(string));
            val.Columns.Add("PasswordResetTokenExpirationMinutes", typeof(int));

            var row = val.NewRow();
            row["Id"] = authSettings.ID;
            row["FK_Organization"] = authSettings.OrganizationID;
            row["Name"] = authSettings.Name;
            row["AuthScheme"] = (int)authSettings.AuthScheme;
            row["SaltLength"] = authSettings.SaltLength;
            row["HashLength"] = authSettings.HashLength;
            row["ExpirationMinutes"] = authSettings.ExpirationMinutes;
            row["Iterations"] = authSettings.Iterations;
            row["AuthKey"] = authSettings.Key;
            row["Issuer"] = authSettings.Issuer;
            row["PasswordResetTokenExpirationMinutes"] = authSettings.PasswordResetTokenExpirationMinutes;

            val.Rows.Add(row);

            return new SqlParameter("@request", SqlDbType.Structured)
            {
                TypeName = "udt_AuthSettings",
                Value = val
            };
        }

        public SqlParameter MapUdtClaim(Guid passwordId, IEnumerable<Models.Passwords.ClaimsEntity> claims)
        {
            DataTable val = new();
            val.Columns.Add("Id", typeof(Guid));
            val.Columns.Add("FK_Password", typeof(string));
            val.Columns.Add("Name", typeof(string));
            val.Columns.Add("Value", typeof(string));

            foreach (var claim in claims)
            {
                var row = val.NewRow();
                row["Id"] = Guid.Empty;
                row["FK_Password"] = passwordId;
                row["Name"] = claim.Key;
                row["Value"] = claim.Value;
                val.Rows.Add(row);
            }

            return new SqlParameter("@claims", SqlDbType.Structured)
            {
                TypeName = "udt_Claim",
                Value = val
            };
        }

        public SqlParameter MapUdtClaimsKeys(IEnumerable<ClaimsKey> claims, string paramName = "@request")
        {
            DataTable val = new();
            val.Columns.Add("Id", typeof(Guid));
            val.Columns.Add("FK_AuthSettings", typeof(Guid));
            val.Columns.Add("Name", typeof(string));

            foreach (ClaimsKey claim in claims)
            {
                var row = val.NewRow();
                row["Id"] = claim.ID;
                row["FK_AuthSettings"] = claim.AuthSettingsId;
                row["Name"] = claim.Name;

                val.Rows.Add(row);
            }

            return new SqlParameter(paramName, SqlDbType.Structured)
            {
                TypeName = "udt_ClaimsKey",
                Value = val
            };
        }

        public SqlParameter MapUdtOrganization(Organization organization)
        {
            DataTable val = new();
            val.Columns.Add("Id", typeof(Guid));
            val.Columns.Add("Name", typeof(string));
            val.Columns.Add("Email", typeof(string));

            var row = val.NewRow();
            row["Id"] = organization.ID;
            row["Name"] = organization.Name;
            row["Email"] = organization.Email;

            val.Rows.Add(row);

            return new SqlParameter("@request", SqlDbType.Structured)
            {
                TypeName = "udt_Organization",
                Value = val
            };
        }

        public SqlParameter MapUdtUser(User user)
        {
            DataTable val = new();
            val.Columns.Add("Id", typeof(Guid));
            val.Columns.Add("FK_AuthSettings", typeof(Guid));
            val.Columns.Add("FirstName", typeof(string));
            val.Columns.Add("LastName", typeof(string));
            val.Columns.Add("Email", typeof(string));
            val.Columns.Add("Username", typeof(string));

            var row = val.NewRow();
            row["Id"] = user.ID;
            row["FK_AuthSettings"] = user.AuthSettingsId;
            row["FirstName"] = user.FirstName;
            row["LastName"] = user.LastName;
            row["Username"] = user.UserName;
            row["Email"] = user.Email;

            val.Rows.Add(row);

            return new SqlParameter("@request", SqlDbType.Structured)
            {
                TypeName = "udt_User",
                Value = val
            };
        }
    }
}
