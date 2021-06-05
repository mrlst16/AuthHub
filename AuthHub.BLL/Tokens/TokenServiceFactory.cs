using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Tokens;
using AuthHub.Interfaces.Users;
using System;

namespace AuthHub.BLL.Tokens
{
    public class TokenServiceFactory : ITokenGeneratoryFactory
    {
        private readonly IPasswordLoader _passwordLoader;
        private readonly IOrganizationLoader _organizationLoader;
        private readonly IUserLoader _userLoader;

        public TokenServiceFactory(
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
                    return (ITokenGenerator)new JWTTokenGenerator();
                default:
                    throw new Exception($"No service found for type {typeof(T)}");
            }
        }
    }
}
