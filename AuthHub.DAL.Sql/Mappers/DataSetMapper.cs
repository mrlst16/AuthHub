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

        public PasswordResetToken MapPasswordResetToken(DataTable? table)
        {
            PasswordResetToken result = null;

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
    }
}
