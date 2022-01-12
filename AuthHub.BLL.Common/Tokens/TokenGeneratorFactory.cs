using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Tokens;
using AuthHub.Interfaces.Users;
using Microsoft.Extensions.Configuration;

namespace AuthHub.BLL.Common.Tokens
{
    public class TokenGeneratorFactory : ITokenGeneratoryFactory
    {
        private readonly IPasswordLoader _passwordLoader;
        private readonly IOrganizationLoader _organizationLoader;
        private readonly IUserLoader _userLoader;
        private readonly IConfiguration _configuration;

        public TokenGeneratorFactory(
            IPasswordLoader passwordLoader,
            IOrganizationLoader organizationLoader,
            IUserLoader userLoader,
            IConfiguration configuration
            )
        {
            _passwordLoader = passwordLoader;
            _organizationLoader = organizationLoader;
            _userLoader = userLoader;
            _configuration = configuration;
        }

        public ITokenGenerator Get<T>() where T : ITokenGenerator
        {
            switch (typeof(T))
            {
                case Type t when typeof(T) == typeof(JWTTokenGenerator):
                    return (ITokenGenerator)new JWTTokenGenerator(_organizationLoader, _passwordLoader, _userLoader, _configuration);
                default:
                    throw new Exception($"No service found for type {typeof(T)}");
            }
        }
    }
}