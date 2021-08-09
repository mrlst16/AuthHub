using AuthHub.Extensions;
using AuthHub.Interfaces.Emails;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Tokens;
using AuthHub.Interfaces.Users;
using AuthHub.Models.Passwords;
using AuthHub.Models.Users;
using CommonCore.Interfaces.Helpers;
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
        private readonly IApplicationHelper _applicationHelper;

        public PasswordService(
            IPasswordLoader loader,
            IOrganizationLoader organizationLoader,
            ITokenGeneratoryFactory tokenGeneratoryFactory,
            IUserLoader userLoader,
            IAuthHubEmailLoader authHubEmailLoader,
            IApplicationHelper applicationHelper
            )
        {
            _loader = loader;
            _organizationLoader = organizationLoader;
            _tokenGeneratoryFactory = tokenGeneratoryFactory;
            _userLoader = userLoader;
            _authHubEmailLoader = authHubEmailLoader;
            _applicationHelper = applicationHelper;
        }

        public async Task<Password> Get(Guid organizationId, string authSettingsName, string username)
            => await _loader.Get(organizationId, authSettingsName, username);

        public async Task RequestOrganizationPasswordReset(UserPointer userPointer)
        {
            PasswordResetToken token = await _loader.GeneratePasswordResetToken(userPointer);
            await _authHubEmailLoader.SendPasswordResetEmail(token);
        }

        public async Task ResetOrganizationPassword(ResetPasswordRequest request)
        {
            await _loader.AuthenticateAndUpdateToken(request);
            var user = await _userLoader.Get((request.OrganizationID, request.AuthSettingsName, request.UserName));
            var newBytes = _applicationHelper.GetBytes(request.NewPassword);
            user.Password.PasswordHash = newBytes;
            await _userLoader.Update(request.OrganizationID, request.AuthSettingsName, user);
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
                Salt = salt,
                Iterations = organizationSettings.Iterations,
                UserName = request.UserName,
                HashLength = organizationSettings.HashLength
            };
        }
    }
}
