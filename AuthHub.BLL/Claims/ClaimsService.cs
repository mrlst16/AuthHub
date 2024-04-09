using AuthHub.Interfaces.Claims;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthHub.BLL.Claims
{
    public class ClaimsService : IClaimsService
    {
        private IClaimsLoader _loader;

        public ClaimsService(
            IClaimsLoader loader
            )
        {
            _loader = loader;
        }

        public async Task SetClaims(Guid userId, IDictionary<string, string> claims)
            => await _loader.SetClaims(userId, claims);
    }
}
