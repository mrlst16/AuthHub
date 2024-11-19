using AuthHub.Api.Middleware;
using System.Linq;
using System.Security.Claims;

namespace AuthHub.Api.Helpers
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal User)
        {
            var claims = User.Identities.First().Claims;
            var claim = claims.FirstOrDefault(x => x.Type == "UserId");
            return int.TryParse(claim.Value, out int res) ? res : -1;
        }

        public static string GetUserName(this ClaimsPrincipal User)
        {
            var claims = User.Identities.First().Claims;
            var claim = claims.FirstOrDefault(x => x.Type == "Username");
            return claim?.Value;
        }

        public static int GetOrganizationId(this ClaimsPrincipal User)
        {
            var claims = User.Identities.First().Claims;
            var claim = claims.FirstOrDefault(x => x.Type == "OrganizationId");
            return int.TryParse(claim.Value, out int res) ? res : -1;
        }
    }
}