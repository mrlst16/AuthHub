using AuthHub.Interfaces.Users;
using AuthHub.Models.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.DAL.Sql.Users
{
    public class UserContext : IUserContext
    {
        private readonly ISqlServerContext _context;

        public UserContext(
            ISqlServerContext context
            )
        {
            _context = context;
        }

        public async Task<User> Create(Guid organizationId, string authSettingsName, User user)
            => await Update(organizationId, authSettingsName, user);

        public async Task<User> Get(Guid organizationId, string authSettingsName, string username)
        {
            SqlParameter[] parameters = new SqlParameter[] { };
            var dataSet = await _context.ExecuteSproc(SprocNames.GetUser, parameters);
            return MapUser(dataSet);
        }

        public async Task<User> Get(UserPointer userPointer)
            => await Get(userPointer.OrganizationID, userPointer.AuthSettingsName, userPointer.UserName);

        public async Task<User> Update(Guid organizationId, string authSettingsName, User user)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                CreateUdtUser(organizationId, authSettingsName, user)
            };

            var dataSet = await _context.ExecuteSproc(SprocNames.SaveUser, parameters);
            if(dataSet.HasDataForTable(0, out DataTable table))
            {
                var row = table.Rows[0];
                user.ID = row.Field<Guid>("Id");
            }
            return user;
        }

        public async Task<User> Update(UserPointer pointer, User user)
            => await Update(pointer.OrganizationID, pointer.AuthSettingsName, user);
        #region Mappings
        private SqlParameter CreateUdtUser(Guid organizationId, string authSettingsName, User user)
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

        private User MapUser(DataSet dataSet)
        {
            User result = null;
            if (dataSet.HasDataForTable(0, out DataTable table))
            {
                var row = table.Rows[0];
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

        #endregion
    }
}
