using System.Security.Claims;

namespace AuthHub.SDK.Extensions
{
    public static class IdentityExtensions
    {
        public static int UserId(this ClaimsPrincipal user)
        {
           string idString = user.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;
           return int.TryParse(idString, out int res) ? res : -1;
        }

        public static bool AreClaimsValid(
            this ClaimsPrincipal user,
            IDictionary<string, string> requiredClaims
                )
        {
            if (requiredClaims == null || !requiredClaims.Any())
                return true;

            var claims = user.Claims;

            foreach (KeyValuePair<string, string> requiredClaim in requiredClaims)
            {
                Claim claim = claims.FirstOrDefault(x => x.Type == requiredClaim.Key);
                if (claim == null || claim.Value != requiredClaim.Value)
                    return false;
            }
            return true;
        }
    }
}