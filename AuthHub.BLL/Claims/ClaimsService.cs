using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthHub.Interfaces.Claims;

namespace AuthHub.BLL.Claims
{
    public class ClaimsService: IClaimsService
    {
        private IClaimsLoader _loader;

        public ClaimsService(
            IClaimsLoader loader
            )
        {
            _loader = loader;
        }

        public async Task SetClaims(int userId, IDictionary<string, string> claims)
            => await _loader.SetClaims(userId, claims);
    }
}
