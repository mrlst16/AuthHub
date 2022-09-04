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
        private readonly ISRDRepository<AuthScheme, Guid> _authSchemeRepo;
        private readonly ISRDRepository<ClaimsEntity, Guid> _claimsEntityRepo;
        private readonly ISRDRepository<User, Guid> _userRepo;

        public UserService(
            IUserLoader loader,
            IClaimsKeyLoader claimsKeyLoader,
            Func<AuthSchemeEnum, ITokenGenerator> tokenGeneratorFactory,
            IPasswordLoader passwordLoader,
            ISRDRepository<AuthSettings, Guid> authSettingsRepo,
            ISRDRepository<AuthScheme, Guid> authSchemeRepo,
            ISRDRepository<ClaimsEntity, Guid> claimsEntityRepo,
            ISRDRepository<User, Guid> userRepo
            )
        {
            _loader = loader;
            _claimsKeyLoader = claimsKeyLoader;
            _tokenGeneratorFactory = tokenGeneratorFactory;
            _passwordLoader = passwordLoader;
            _authSettingsRepo = authSettingsRepo;
            _authSchemeRepo = authSchemeRepo;
            _claimsEntityRepo = claimsEntityRepo;
            _userRepo = userRepo;
        }

        public async Task CreateAsync(CreateUserRequest item)
        {
            var authSettings = await _authSettingsRepo.ReadAsync(item.AuthSettingsId);
            var authScheme = await _authSchemeRepo.ReadAsync(authSettings.AuthSchemeID);

            var tokenGenerator = _tokenGeneratorFactory(authScheme);

            (byte[] passwordHash, byte[] salt, IEnumerable<ClaimsKey> claimsKeys)
                    = await tokenGenerator.NewHash(item.Password, authSettings);

            var newUserId = Guid.NewGuid();
            var newPasswordId = Guid.NewGuid();

            User user = new()
            {
                Id = newUserId,
                Email = item.Email,
                FirstName = item.FirstName,
                LastName = item.LastName,
                UserName = item.UserName,
                AuthSettingsId = item.AuthSettingsId,
                IsOrganization = false,
                Password = new()
                {
                    Id = newPasswordId,
                    UserId = newUserId,
                    PasswordHash = passwordHash,
                    Salt = salt,
                    Claims = claimsKeys.Where(x => x.IsDefault)
                        .Select(x => new ClaimsEntity()
                        {
                            Id = Guid.NewGuid(),
                            Value = x.DefaultValue,
                            Key = x.Name,
                            ClaimsKeyId = x.Id,
                            PasswordId = newPasswordId
                        }).ToList()
                }
            };

            user.Id = await _loader.SaveAsync(user);
        }

        public async Task<User> ReadAsync(Guid id)
            => await _loader.GetAsync(id);
    }
}
