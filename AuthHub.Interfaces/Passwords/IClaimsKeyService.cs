using AuthHub.Models.Entities.Passwords;
using System;
using System.Collections.Generic;

namespace AuthHub.Interfaces.Passwords
{
    public interface IClaimsKeyService
    {
        Task<IEnumerable<ClaimsKey>> GetAsync(int authSettingsId);
    }
}
