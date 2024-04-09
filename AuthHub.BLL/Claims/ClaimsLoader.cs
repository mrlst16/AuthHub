using AuthHub.Interfaces.Claims;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthHub.BLL.Claims
{
    public class ClaimsLoader : IClaimsLoader
    {
        private readonly IClaimsContext _context;

        public ClaimsLoader(
            IClaimsContext context
            )
        {
            _context = context;
        }

        public async Task SetClaims(Guid userId, IDictionary<string, string> claims)
            => await _context.SetClaims(userId, claims);
    }
}
