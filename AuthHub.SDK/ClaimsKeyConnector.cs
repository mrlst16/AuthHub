using AuthHub.Models.Passwords;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthHub.SDK
{
    public class ClaimsKeyConnector : IClaimsKeyConnector
    {
        private readonly IApiConnector _apiConnector;

        public ClaimsKeyConnector(
            IApiConnector apiConnector
            )
        {
            _apiConnector = apiConnector;
        }

        public async Task<IEnumerable<ClaimsKey>> Get(Guid authSettingsId)
            => await _apiConnector.Get<List<ClaimsKey>>("claimskey/get", queryParams: new Dictionary<string, string>()
            {
                { "authSettingsId", authSettingsId.ToString()}
            });
    }
}
