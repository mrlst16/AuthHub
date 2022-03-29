using AuthHub.DAL.Sql.Mappers;
using AuthHub.Interfaces.Users;
using AuthHub.Models.Users;
using System.Data.SqlClient;

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

        public async Task DeleteAsync(User item)
        {
            item.DeletedUTC = DateTime.UtcNow;
        }

        public async Task<User> Get(Guid organizationId, string authSettingsName, string username)
        {
            var result = new User();
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@organizationId", organizationId),
                new SqlParameter("@authSettingsName", authSettingsName),
                new SqlParameter("@userName", username),
                new SqlParameter("@id", Guid.Empty)
            };
            var dataSet = await _context.ExecuteSproc(SprocNames.GetUser, parameters);

            return _mapper.MapUser(dataSet);
        }

        public async Task<User> Get(UserPointer userPointer)
            => await Get(userPointer.OrganizationID, userPointer.AuthSettingsName, userPointer.UserName);

        public async Task<User> Get(Guid authSettingsId, string userName)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@authSettingsId", authSettingsId),
                new SqlParameter("@userName", userName)
            };
            var dataSet = await _context.ExecuteSproc(SprocNames.GetUser, parameters);

            return _mapper.MapUser(dataSet);
        }

        public async Task<User> GetAsync(Guid id)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@id", id)
            };
            var dataSet = await _context.ExecuteSproc(SprocNames.GetUser, parameters);

            return _mapper.MapUser(dataSet);
        }

        public async Task SaveAsync(User item)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                _udtMapper.MapUdtUser(item),
            };

            var dataSet = await _context.ExecuteSproc(SprocNames.SaveUser, parameters);
        }

        public async Task<User> Update(Guid organizationId, string authSettingsName, User user)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                _udtMapper.MapUdtUser(user),
                new SqlParameter("@organizationId", organizationId)
            };

            var dataSet = await _context.ExecuteSproc(SprocNames.SaveUser, parameters);
            user.ID = _mapper.MapSingle<Guid>(dataSet);
            return user;
        }

        public async Task<User> Update(UserPointer pointer, User user)
            => await Update(pointer.OrganizationID, pointer.AuthSettingsName, user);
    }
}
