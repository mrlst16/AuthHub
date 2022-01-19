using AuthHub.DAL.Sql.Mappers;
using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Passwords;
using System.Data;
using System.Data.SqlClient;

namespace AuthHub.DAL.Sql.Passwords
{
    public class ClaimsKeyContext : IClaimsKeyContext
    {

        private readonly IDataSetMapper _mapper;
        private readonly IUdtMapper _udtMapper;
        private readonly ISqlServerContext _context;

        public ClaimsKeyContext(
            IDataSetMapper mapper,
            IUdtMapper udtMapper,
            ISqlServerContext context
            )
        {
            _mapper = mapper;
            _udtMapper = udtMapper;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authSettingsId">The id of the auth settings for whom to get claims keys.  Note that this is the a foreign key to authsettings.id</param>
        /// <returns></returns>
        public async Task<IEnumerable<ClaimsKey>> GetAsync(Guid authSettingsId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@authSettingsId", authSettingsId)
            };

            var dataSet = await _context.ExecuteSproc(SprocNames.GetClaimsKeys, parameters);
            if (dataSet.HasDataForTable(0, out DataTable? table))
                return _mapper.MapClaimsKeys(table);

            return new List<ClaimsKey>();
        }

        public async Task SaveAsync(IEnumerable<ClaimsKey> item)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                _udtMapper.MapUdtClaimsKeys(item)
            };

            await _context.ExecuteSproc(SprocNames.SaveClaimsKeys, parameters);
        }
    }
}
