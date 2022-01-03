using AuthHub.DAL.Sql.Mappers;
using AuthHub.Interfaces.Organizations;
using AuthHub.Models.Organizations;
using System.Data;
using System.Data.SqlClient;

namespace AuthHub.DAL.Sql.Organizations
{
    public class OrganizationContext : IOrganizationContext
    {
        private readonly ISqlServerContext _context;
        private readonly IDataSetMapper _mapper;
        private readonly IUdtMapper _udtMapper;

        public OrganizationContext(
            ISqlServerContext context,
            IDataSetMapper mapper,
            IUdtMapper udtMapper
            )
        {
            _context = context;
            _mapper = mapper;
            _udtMapper = udtMapper;
        }

        public async Task Create(Organization request)
            => await Update(request);

        public async Task<Organization> Get(Guid id)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@id", id)
            };

            var dataSet = await _context.ExecuteSproc(SprocNames.GetOrganization, parameters);

            return _mapper.MapOrganization(dataSet);
        }

        public async Task<Organization> Get(string name)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@name", name)
            };

            var dataSet = await _context.ExecuteSproc(SprocNames.GetOrganization, parameters);

            return _mapper.MapOrganization(dataSet);
        }

        public async Task<AuthSettings> GetSettings(Guid organizationId, string name)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@organizationId", organizationId),
                new SqlParameter("@name", name)
            };

            var dataSet = await _context.ExecuteSproc(SprocNames.GetAuthSettings, parameters);
            if (dataSet.HasDataForTable(0, out DataTable? table))
                return _mapper.MapAuthSettings(table);

            return new AuthSettings();
        }

        public async Task<(bool, Organization)> Update(Organization request)
        {
            SqlParameter[] parameters = new SqlParameter[]{
                _udtMapper.MapUdtOrganization(request)
            };

            var dataSet = await _context.ExecuteSproc(SprocNames.SaveOrganization, parameters);
            if (
                dataSet.HasDataForTable(0, out DataTable? table)
                    && table.HasDataForRow(0, out DataRow? row)
                ) request.ID = row.Field<Guid>("id");

            return (true, request);
        }

        public async Task<(bool, AuthSettings)> UpdateSettings(Guid organizationId, AuthSettings request)
        {
            SqlParameter[] parameters = new SqlParameter[]{
                _udtMapper.MapUdtAuthSettings(request)
            };

            var dataSet = await _context.ExecuteSproc(SprocNames.SaveAuthSettings, parameters);

            if (
                dataSet.HasDataForTable(0, out DataTable? table)
                    && table.HasDataForRow(0, out DataRow? row)
                ) request.ID = row.Field<Guid>("id");

            return (true, request);
        }
    }
}
