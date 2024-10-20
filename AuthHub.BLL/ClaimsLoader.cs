using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthHub.Interfaces.Claims;

namespace AuthHub.BLL
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

        public async Task SetClaims(int userId, IDictionary<string, string> claims)
            => await _context.SetClaims(userId, claims);
    }
}
