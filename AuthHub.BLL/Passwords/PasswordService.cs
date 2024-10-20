using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Tokens;
using AuthHub.Models.Entities.Passwords;
using AuthHub.Models.Enums;
using AuthHub.Models.Requests;
using System;
using System.Threading.Tasks;

namespace AuthHub.BLL.Passwords
{
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordLoader _loader;
        private readonly IOrganizationLoader _organizationLoader;
        private readonly Func<AuthSchemeEnum, ITokenGenerator> _tokenGeneratoryFactory;

        public PasswordService(
            IPasswordLoader loader,
            IOrganizationLoader organizationLoader,
            Func<AuthSchemeEnum, ITokenGenerator> tokenGeneratoryFactory
            )
        {
            _loader = loader;
            _organizationLoader = organizationLoader;
            _tokenGeneratoryFactory = tokenGeneratoryFactory;
        }

        public async Task<Password> Get(int organizationId, string authSettingsName, string username)
            => await _loader.Get(organizationId, authSettingsName, username);

        public async Task<(bool, Password)> Set<T>(PasswordRequest request)
            where T : ITokenGenerator
        {
            var result = await GeneratePasswordRecord<T>(request);
            return await _loader.Set(request.OrganizationID, request.SettingsName, result);
        }

        private async Task<Password> GeneratePasswordRecord<T>(PasswordRequest request)
            where T : ITokenGenerator
        {
            var organization = await _organizationLoader.Get(request.OrganizationID);
            var tokenGenerator = _tokenGeneratoryFactory(AuthSchemeEnum.JWT);
            var (passwordHash, salt) = await tokenGenerator.NewHash(request, organization);

            return new Password()
            {
                PasswordHash = passwordHash,
                Salt = salt
            };
        }
    }
}
