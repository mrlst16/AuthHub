using AuthHub.BLL.Common.Extensions;
using AuthHub.Common.Extensions;
using AuthHub.Interfaces.Emails;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Tokens;
using AuthHub.Interfaces.Users;
using AuthHub.Models.Passwords;
using AuthHub.Models.Users;
using CommonCore.Interfaces.Helpers;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace AuthHub.BLL.Passwords
{
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordLoader _loader;
        private readonly IOrganizationLoader _organizationLoader;
        private readonly ITokenGeneratoryFactory _tokenGeneratoryFactory;
        private readonly IUserLoader _userLoader;
        private readonly IAuthHubEmailLoader _authHubEmailLoader;
        private readonly IApplicationConsistency _applicationHelper;
        private readonly IConfiguration _configuration;

        public PasswordService(
            IPasswordLoader loader,
            IOrganizationLoader organizationLoader,
            ITokenGeneratoryFactory tokenGeneratoryFactory,
            IUserLoader userLoader,
            IAuthHubEmailLoader authHubEmailLoader,
            IApplicationConsistency applicationHelper,
            IConfiguration configuration
            )
        {
            _loader = loader;
            _organizationLoader = organizationLoader;
            _tokenGeneratoryFactory = tokenGeneratoryFactory;
            _userLoader = userLoader;
            _authHubEmailLoader = authHubEmailLoader;
            _applicationHelper = applicationHelper;
            _configuration = configuration;
        }

        public async Task<Password> Get(Guid organizationId, string authSettingsName, string username)
            => await _loader.Get(organizationId, authSettingsName, username);

        public async Task RequestOrganizationPasswordReset(UserPointer userPointer)
        {
            var orgId = _configuration.AuthHubOrganizationId();
            userPointer = (orgId, "audder_clients", userPointer.UserName);

            PasswordResetToken token = await _loader.GenerateAndSavePasswordResetToken(userPointer);

            await _authHubEmailLoader.SendPasswordResetEmail(token);
        }

        public async Task ResetOrganizationPassword(SetPasswordRequest request)
        {
            await _loader.AuthenticateAndUpdateToken(request);
            var password = await _loader.GetByUserIdAsync(request.UserId);
            var newBytes = _applicationHelper.GetBytes(request.NewPassword);
            password.PasswordHash = newBytes;
            await _loader.Set(password);
        }

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
            var organizationSettings = organization.GetSettings(request.SettingsName);
            var tokenGenerator = _tokenGeneratoryFactory.Get<T>();
            var (passwordHash, salt) = await tokenGenerator.GetHash(request, organization);

            return new Password()
            {
                PasswordHash = passwordHash,
                Salt = salt
            };
        }
    }
}
