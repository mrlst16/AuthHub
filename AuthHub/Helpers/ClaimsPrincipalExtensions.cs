using AuthHub.Api.Middleware;
using System.Linq;
using System.Security.Claims;

namespace AuthHub.Api.Helpers
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal User)
        {
            var claims = User.Identities.Where(x => x.AuthenticationType == nameof(UserCredentialsAuthenticationHandler));
            var claim = claims.SelectMany(x => x.Claims).FirstOrDefault(x => x.Type == "UserId");
            return Guid.TryParse(claim.Value, out Guid res) ? res : Guid.Empty;
        }

        public static Guid GetOrganizationId(this ClaimsPrincipal User)
        {
            var claims = User.Identities.Where(x => x.Name == nameof(APICredentialsAuthenticationHandler));
            var claim = claims.SelectMany(x => x.Claims).FirstOrDefault(x => x.Type == "OrganizationId");
            return Guid.TryParse(claim.Value, out Guid res) ? res : Guid.Empty;
        }
    }
}