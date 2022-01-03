using AuthHub.DAL.Sql.Mappers;
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
        private readonly IDataSetMapper _mapper;
        private readonly IUdtMapper _udtMapper;

        public UserContext(
            ISqlServerContext context,
            IDataSetMapper mapper,
            IUdtMapper udtMapper
            )
        {
            _context = context;
            _mapper = mapper;
            _udtMapper = udtMapper;
        }

        public async Task<User> Create(Guid organizationId, string authSettingsName, User user)
            => await Update(organizationId, authSettingsName, user);

        public async Task<User> Get(Guid organizationId, string authSettingsName, string username)
        {
            var result = new User();
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@organizationId", organizationId),
                new SqlParameter("@authSettingsName", authSettingsName),
                new SqlParameter("@userName", username)
            };
            var dataSet = await _context.ExecuteSproc(SprocNames.GetUser, parameters);
            if (dataSet.HasDataForTable(0, out DataTable? table))
            {
                result = _mapper.MapUser(table);
                if (dataSet.HasDataForTable(1, out DataTable? table2))
                {
                    result.Password = _mapper.MapPassword(table2);
                    if (dataSet.HasDataForTable(2, out DataTable? table3))
                    {
                        result.Password.Claims = _mapper.MapClaims(table3).ToList();
                    }
                }
            }
            return result;
        }

        public async Task<User> Get(UserPointer userPointer)
            => await Get(userPointer.OrganizationID, userPointer.AuthSettingsName, userPointer.UserName);

        public async Task<User> Update(Guid organizationId, string authSettingsName, User user)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                _udtMapper.MapUdtUser(organizationId, authSettingsName, user)
            };

            var dataSet = await _context.ExecuteSproc(SprocNames.SaveUser, parameters);
            if (dataSet.HasDataForTable(0, out DataTable? table))
            {
                var row = table?.Rows[0];
                user.ID = row?.Field<Guid>("Id") ?? Guid.Empty;
            }
            return user;
        }

        public async Task<User> Update(UserPointer pointer, User user)
            => await Update(pointer.OrganizationID, pointer.AuthSettingsName, user);
    }
}
