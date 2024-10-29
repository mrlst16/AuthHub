using AuthHub.Interfaces.Organizations;
using AuthHub.Models.Entities.Organizations;
using AuthHub.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthHub.Interfaces.Hashing;

namespace AuthHub.BLL.Organizations
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationContext _context;
        private readonly IHasher _hasher;

        public OrganizationService(
            IOrganizationContext context,
            IHasher hasher
            )
        {
            _context = context;
            _hasher = hasher;
        }

        public async Task<Organization> CreateAsync(CreateOrganizationRequest request)
        {
            (var passwordHash, var salt) = _hasher.HashPasswordWithSalt(request.Password, 50, 10, 100);

            var org = new Organization()
            {
                Name = request.Name,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = salt
            };
            await _context.Create(org);

            return org;
        }



        public async Task<Organization> GetAsync(int organizationId)
            => await _context.Get(organizationId);

        public async Task<Organization> GetAsync(string name)
            => await _context.Get(name);

        public async Task<IList<Organization>> GetAll()
            => await _context.GetAll();

        public async Task<AuthSettings> GetSettings(int organizationId, string name)
            => await _context.GetSettings(organizationId, name);
        public async Task<(bool, Organization)> Update(Organization request)
            => await _context.Update(request);
        public async Task<(bool, AuthSettings)> UpdateSettings(int organizationId, AuthSettings request)
            => await _context.UpdateSettings(organizationId, request);
    }
}