using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Tokens;
using AuthHub.Interfaces.Users;

namespace AuthHub.BLL.Common.Tokens
{
    public class TokenGeneratorFactory : ITokenGeneratoryFactory
    {
        private readonly IPasswordLoader _passwordLoader;
        private readonly IOrganizationLoader _organizationLoader;
        private readonly IUserLoader _userLoader;

        public TokenGeneratorFactory(
            IPasswordLoader passwordLoader,
            IOrganizationLoader organizationLoader,
            IUserLoader userLoader
            )
        {
            _passwordLoader = passwordLoader;
            _organizationLoader = organizationLoader;
            _userLoader = userLoader;
        }

        public ITokenGenerator Get<T>() where T : ITokenGenerator
        {
            switch (typeof(T))
            {
                case Type t when typeof(T) == typeof(JWTTokenGenerator):
                    return (ITokenGenerator)new JWTTokenGenerator(_organizationLoader, _passwordLoader);
                default:
                    throw new Exception($"No service found for type {typeof(T)}");
            }
        }
    }
}