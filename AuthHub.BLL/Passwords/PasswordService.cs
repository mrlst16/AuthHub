using AuthHub.BLL.Tokens;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Tokens;
using AuthHub.Models.Organizations;
using AuthHub.Models.Passwords;
using AuthHub.Models.Users;
using CommonCore2.Extensions;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.BLL.Passwords
{
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordLoader _loader;
        private readonly IOrganizationLoader _organizationLoader;
        private readonly ITokenGeneratoryFactory _tokenGeneratoryFactory;

        public PasswordService(
            IPasswordLoader loader,
            IOrganizationLoader organizationLoader,
            ITokenGeneratoryFactory tokenGeneratoryFactory
            )
        {
            _loader = loader;
            _organizationLoader = organizationLoader;
            _tokenGeneratoryFactory = tokenGeneratoryFactory;
        }

        public async Task<Password> Get(Guid organizationId, string username)
            => await _loader.Get(organizationId, username);

        public async Task<(bool, Password)> Set<T>(PasswordRequest request)
            where T : ITokenGenerator
        {
            var result = await GeneratePasswordRecord<T>(request);
            return await _loader.Set(request.OrganizationID, result);
        }

        private async Task<Password> GeneratePasswordRecord<T>(PasswordRequest request)
            where T : ITokenGenerator
        {
            var organization = await _organizationLoader.Get(request.OrganizationID);
            var organizationSettings = organization.Settings;
            var tokenGenerator = _tokenGeneratoryFactory.Get<T>();
            var (passwordHash, salt) = await tokenGenerator.GetHash(request, organization);

            return new Password()
            {
                PasswordHash = passwordHash,
                Salt = salt,
                Iterations = organizationSettings.Iterations,
                UserName = request.UserName,
                HashLength = organizationSettings.HashLength
            };
        }
    }
}
