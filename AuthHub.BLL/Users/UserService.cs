using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Tokens;
using AuthHub.Interfaces.Users;
using AuthHub.Models.Enums;
using AuthHub.Models.Organizations;
using AuthHub.Models.Passwords;
using AuthHub.Models.Users;
using Common.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthHub.BLL.Users
{
    public class UserService : IUserService
    {
        private readonly IUserLoader _loader;
        private readonly IClaimsKeyLoader _claimsKeyLoader;
        private readonly Func<AuthSchemeEnum, ITokenGenerator> _tokenGeneratorFactory;
        private readonly IPasswordLoader _passwordLoader;
        private readonly ISRDRepository<AuthSettings, Guid> _authSettingsRepo;
        private readonly ISRDRepository<ClaimsEntity, Guid> _claimsEntityRepo;

        public UserService(
            IUserLoader loader,
            IClaimsKeyLoader claimsKeyLoader,
            Func<AuthSchemeEnum, ITokenGenerator> tokenGeneratorFactory,
            IPasswordLoader passwordLoader,
            ISRDRepository<AuthSettings, Guid> authSettingsRepo
            )
        {
            _loader = loader;
            _claimsKeyLoader = claimsKeyLoader;
            _tokenGeneratorFactory = tokenGeneratorFactory;
            _passwordLoader = passwordLoader;
            _authSettingsRepo = authSettingsRepo;
        }

        public async Task CreateAsync(SaveUserRequest item)
        {

            var authSettings = await _authSettingsRepo.ReadAsync(item.AuthSettingsId);

            var tokenGenerator = _tokenGeneratorFactory(authSettings.AuthScheme);

            (byte[] passwordHash, byte[] salt, IEnumerable<ClaimsKey> claimsKeys)
                    = await tokenGenerator.NewHash(item.Password, authSettings);

            User user = new()
            {
                Email = item.Email,
                FirstName = item.FirstName,
                LastName = item.LastName,
                UserName = item.UserName,
                AuthSettingsId = item.AuthSettingsId,
                IsOrganization = false
            };
            user.Id = await _loader.SaveAsync(user);

            Password password = new()
            {
                UserId = user.Id,
                PasswordHash = passwordHash,
                Salt = salt
            };

            var claims = claimsKeys.Where(x => x.IsDefault)
                .Select(x => new ClaimsEntity()
                {
                    Id = Guid.NewGuid(),
                    Value = x.DefaultValue,
                    Key = x.Name,
                    ClaimsKeyId = x.Id,
                    PasswordId = password.Id
                });

            //TODO: Figure out how to save this
        }

        public async Task<User> ReadAsync(Guid id)
            => await _loader.GetAsync(id); 
    }
}
