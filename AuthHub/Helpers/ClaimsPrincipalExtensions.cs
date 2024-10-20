using AuthHub.Api.Middleware;
using System.Linq;
using System.Security.Claims;

namespace AuthHub.Api.Helpers
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal User)
        {
            var claims = User.Identities.Where(x => x.AuthenticationType == nameof(UserCredentialsAuthenticationHandler));
            var claim = claims.SelectMany(x => x.Claims).FirstOrDefault(x => x.Type == "UserId");
            return int.TryParse(claim.Value, out int res) ? res : -1;
        }

        public static int GetOrganizationId(this ClaimsPrincipal User)
        {
            var claims = User.Identities.Where(x => x.Name == nameof(APICredentialsAuthenticationHandler));
            var claim = claims.SelectMany(x => x.Claims).FirstOrDefault(x => x.Type == "OrganizationId");
            return int.TryParse(claim.Value, out int res) ? res : -1;
        }
    }
}