using AuthHub.DAL.Sql.Mappers;
using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Passwords;
using System.Data;
using System.Data.SqlClient;

namespace AuthHub.DAL.Sql.Passwords
{
    public class PasswordsContext : IPasswordContext
    {
        private readonly IDataSetMapper _mapper;
        private readonly IUdtMapper _udtMapper;
        private readonly ISqlServerContext _context;

        public PasswordsContext(
            IDataSetMapper mapper,
            IUdtMapper udtMapper,
            ISqlServerContext context
            )
        {
            _mapper = mapper;
            _udtMapper = udtMapper;
            _context = context;
        }

        public async Task<Password> Get(Guid organizationId, string authSettingsname, string username)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@organizationId", organizationId),
                new SqlParameter("@authSettingsname", authSettingsname),
                new SqlParameter("@username", username)
            };

            var dataSet = await _context.ExecuteSproc(SprocNames.GetPassword, parameters);
            if (dataSet.HasDataForTable(0, out DataTable? table))
                return _mapper.MapPassword(table);

            return new Password();
        }

        public async Task<PasswordResetToken> GetPasswordResetToken(string email, Guid organizationId, string authSettingsName, DateTime expirationDate)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@organizationId", organizationId),
                new SqlParameter("@authSettingsname", authSettingsName),
                new SqlParameter("@email", email)
            };

            var dataSet = await _context.ExecuteSproc(SprocNames.GetPasswordResetToken, parameters);
            if (dataSet.HasDataForTable(0, out DataTable? table))
                return _mapper.MapPasswordResetToken(table);

            return new PasswordResetToken();
        }

        public async Task<(bool, Password)> Set(Guid organizationId, string authSettingsname, Password request)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                _udtMapper.MapUdPassword(request),
                _udtMapper.MapUdtClaim(request.ID, request.Claims)
            };
            bool success = true;
            Password result = new Password();
            var dataSet = await _context.ExecuteSproc(SprocNames.SavePassword, parameters);

            success = true;
            result.ID = _mapper.MapSingle<Guid>(dataSet);
            return (success, result);
        }

        public async Task SavePasswordResetToken(PasswordResetToken token)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                _udtMapper.MapUdPasswordResetToken(token)
            };

            await _context.ExecuteSproc(SprocNames.SavePasswordResetToken, parameters);
        }

        public async Task<PasswordResetToken> GetPasswordResetToken(Guid userId)
        {
            var dataSet = await _context.ExecuteSproc(SprocNames.GetPasswordResetToken, new SqlParameter("@userId", userId));
            if (dataSet.HasDataForTable(0, out DataTable? table))
                return _mapper.MapPasswordResetToken(table);

            return new PasswordResetToken();
        }
    }
}