using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Users;
using AuthHub.Models.Passwords;
using AuthHub.Models.Requests;
using AuthHub.Models.Users;
using Common.Helpers;
using Common.Models.Exceptions;
using System;
using System.Linq;
using System.Threading.Tasks;
using AuthHub.BLL.Common.Exceptions;
using AuthHub.Models.Organizations;
using AuthHub.Models.QueryResultSets;
using Common.Interfaces.Repository;

namespace AuthHub.BLL.Passwords
{
    public class PasswordLoader : IPasswordLoader
    {
        private readonly IPasswordContext _passwordContext;
        private readonly IOrganizationContext _organizationContext;
        private readonly IUserContext _userContext;
        private readonly ISRDRepository<Password, Guid> _passwordRepo;
        private readonly ISRDRepository<User, Guid> _userRepo;
        private readonly ISRDRepository<AuthSettings, Guid> _authSettingsRepo;

        public PasswordLoader(
            IPasswordContext passwordContext,
            IOrganizationContext organizationContext,
            IUserContext userContext,
            ISRDRepository<Password, Guid> passwordRepo,
            ISRDRepository<User, Guid> userRepo,
            ISRDRepository<AuthSettings, Guid> authSettingsRepo
            )
        {
            _passwordContext = passwordContext;
            _organizationContext = organizationContext;
            _userContext = userContext;
            _passwordRepo = passwordRepo;
            _userRepo = userRepo;
            _authSettingsRepo = authSettingsRepo;
        }

        public async Task AuthenticateAndUpdateToken(SetPasswordRequest request)
        {
            var token = await _passwordContext.GetPasswordResetToken(request.UserId);

            if (token == null)
                throw new HttpException("Unable to authenticate reset password token", 403);

            if (!string.Equals(request.VerificationCode, token.VerificationCode, StringComparison.InvariantCulture))
                throw new HttpException("Unable to authenticate reset password token", 403);
        }

        public async Task<Password> Get(Guid organizationId, string authSettingsname, string username)
            => await _passwordContext.Get(organizationId, authSettingsname, username);

        public async Task<(bool, Password)> Set(Guid organizationId, string authSettingsname, Password request)
        {
            return await _passwordContext.Set(organizationId, authSettingsname, request);
        }

        public async Task<PasswordResetToken> GenerateAndSavePasswordResetToken(UserPointer userPointer)
        {
            var user = await _userContext.Get(userPointer);
            var authSettings = await _organizationContext.GetSettings(userPointer.OrganizationID, userPointer.UserName);

            var result = new PasswordResetToken()
            {
                UserId = user.Id,
                Email = user.Email,
                ExpirationDate = DateTime.UtcNow.AddMinutes(authSettings.PasswordResetTokenExpirationMinutes),
                VerificationCode = StringHelper.RandomAlphanumericString(6)
            };
            await _passwordContext.SavePasswordResetToken(result);
            return (result);
        }



        public async Task<Password> GetByUserIdAsync(Guid userId)
            => await _passwordContext.GetByUserIdAsync(userId);

        public async Task<Guid> Set(Password request)
            => await _passwordContext.Set(request);

        public async Task<LoginChallengeResponse> GetLoginChallenge(Guid authSettingsId, string userName)
            => await _passwordContext.GetLoginChallenge(authSettingsId, userName);

        public async Task<LoginChallengeResponse> GetLoginChallenge(Guid userId)
        {
            var password = (await _passwordRepo.ReadAsync(x => x.UserId == userId))
                .FirstOrDefault();
            if (password == null) throw new PasswordNotFoundException(userId);
            var result = new LoginChallengeResponse()
            {
                StoredPasswordHash = password.PasswordHash,
                Salt = password.Salt,
            };

            var user = await _userRepo.ReadAsync(userId);
            var authSettings = await _authSettingsRepo.ReadAsync(user.AuthSettingsId);

            result.Iterations = authSettings.Iterations;
            result.Length = authSettings.HashLength;

            return result;
        }

        public async Task<TokenAssemblyData> GetTokenAssemblyData(Guid userId)
        {
            var user = await _userRepo.ReadAsync(userId);
            var password = (await _passwordRepo.ReadAsync(x => x.UserId == userId))
                .FirstOrDefault();

            var authSettings = await _authSettingsRepo.ReadAsync(user.AuthSettingsId);

            return new TokenAssemblyData()
            {
                UserName = user.UserName,
                
            };
        }
    }
}
