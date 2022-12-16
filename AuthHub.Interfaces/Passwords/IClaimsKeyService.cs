using System;
using System.Collections.Generic;
using AuthHub.Models.Entities.Passwords;

namespace AuthHub.Interfaces.Passwords
{
    public interface IClaimsKeyService
    {
        Task<IEnumerable<ClaimsKey>> GetAsync(Guid authSettingsId);
    }
}
