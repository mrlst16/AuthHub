using AuthHub.DAL.Sql.Mappers;
using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Passwords;
using AuthHub.Models.Requests;
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
                _udtMapper.MapUdtClaim(request.Id, request.Claims)
            };
            bool success = true;
            Password result = new Password();
            var dataSet = await _context.ExecuteSproc(SprocNames.SavePassword, parameters);

            success = true;
            result.Id = _mapper.MapSingle<Guid>(dataSet);
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

        public async Task<Password> GetByUserIdAsync(Guid userId)
        {
            var dataSet = await _context.ExecuteSproc(SprocNames.GetPasswordByUserId, new SqlParameter("@userId", userId));
            if (dataSet.HasDataForTable(0, out DataTable? table))
                return _mapper.MapPassword(table);
            return new Password();
        }

        public async Task<Guid> Set(Password request)
        {
            throw new NotImplementedException();
            SqlParameter[] parameters = new SqlParameter[] {
                _udtMapper.MapUdPassword(request)
            };
            if (request?.Claims?.Any() ?? false)
            {
                parameters.Append(_udtMapper.MapUdtClaim(request.Id, request.Claims));
            }
            var dataSet = await _context.ExecuteSproc(SprocNames.SavePassword, parameters);
        }

        public async Task<LoginChallengeResponse> GetLoginChallenge(Guid authSettingsId, string userName)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@authSettingsId", authSettingsId),
                new SqlParameter("@userName", userName),
            };
            var dataSet = await _context.ExecuteSproc(SprocNames.GetLoginChallengeModel, parameters);
            return DataSetMapper.MapLoginChallengeResponse(dataSet);
        }
    }
}