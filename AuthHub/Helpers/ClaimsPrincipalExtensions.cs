using AuthHub.Api.Middleware;
using System.Linq;
using System.Security.Claims;

namespace AuthHub.Api.Helpers
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal User)
        {
            var claims = User.Identities.Where(x => x.Name == nameof(UserCredentialsAuthenticationHandler));
            var claim = claims.SelectMany(x => x.Claims).FirstOrDefault(x => x.Type == "UserId");
            return Guid.TryParse(claim.Value, out Guid res) ? res : Guid.Empty;
        }
    }
}