using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.SDK.Extensions
{
    public static class IdentityExtensions
    {
        public static Guid UserId(this ClaimsPrincipal user)
        {
           string idString = user.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;
           return Guid.TryParse(idString, out Guid res) ? res : Guid.Empty;
        }
    }
}
