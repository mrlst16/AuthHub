using AuthHub.Models.Passwords;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthHub.SDK
{
    public interface IClaimsKeyConnector
    {
        Task<IEnumerable<ClaimsKey>> Get(Guid authSettingsId);
    }
}