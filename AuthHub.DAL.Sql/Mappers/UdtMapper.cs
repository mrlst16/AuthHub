﻿using AuthHub.Models.Passwords;
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
            val.Columns.Add("UserName", typeof(string));
            val.Columns.Add("Email", typeof(string));
            val.Columns.Add("OrganizationID", typeof(Guid));
            val.Columns.Add("AuthSettingsName", typeof(string));
            val.Columns.Add("ExpirationDate", typeof(DateTime));
            val.Columns.Add("Salt", typeof(byte[]));
            val.Columns.Add("ExpirationDate", typeof(DateTime));
            val.Columns.Add("Token", typeof(byte[]));
            val.Columns.Add("IsActive", typeof(bool));
            val.Columns.Add("Password", typeof(byte[]));

            var row = val.NewRow();
            row["Id"] = token.ID;
            row["UserName"] = token.UserName;
            row["Email"] = token.Email;
            row["OrganizationID"] = token.OrganizationID;
            row["AuthSettingsName"] = token.AuthSettingsName;
            row["ExpirationDate"] = token.ExpirationDate;
            row["Token"] = token.Token;
            row["IsActive"] = token.IsActive;
            row["Password"] = token.Password;

            val.Rows.Add(row);

            return new SqlParameter("@request", SqlDbType.Structured)
            {
                TypeName = "udt_PasswordResetToken",
                Value = val
            };
        }

        public SqlParameter MapUdtClaim(Guid passwordId, IEnumerable<SerializableClaim> claims)
        {
            DataTable val = new();
            val.Columns.Add("Id", typeof(Guid));
            val.Columns.Add("FK_Password", typeof(string));
            val.Columns.Add("Key", typeof(string));
            val.Columns.Add("Value", typeof(string));

            foreach (var claim in claims)
            {
                var row = val.NewRow();
                row["FK_Password"] = passwordId;
                row["Key"] = claim.Key;
                row["Value"] = claim.Value;
                val.Rows.Add(row);
            }

            return new SqlParameter("@claims", SqlDbType.Structured)
            {
                TypeName = "udt_Claim",
                Value = val
            };
        }

        public SqlParameter MapUdtUser(Guid organizationId, string authSettingsName, User user)
        {
            DataTable val = new();
            val.Columns.Add("Id", typeof(Guid));
            val.Columns.Add("AuthSettingsId", typeof(string));
            val.Columns.Add("FirstName", typeof(string));
            val.Columns.Add("LastName", typeof(string));
            val.Columns.Add("Email", typeof(string));
            val.Columns.Add("Username", typeof(string));

            var row = val.NewRow();
            row["Id"] = user.ID;
            row["AuthSettingsId"] = authSettingsName;
            row["FirstName"] = user.FirstName;
            row["LastName"] = user.LastName;
            row["Username"] = user.UserName;

            val.Rows.Add(row);

            return new SqlParameter("@request", SqlDbType.Structured)
            {
                TypeName = "udt_User",
                Value = val
            };
        }
    }
}
