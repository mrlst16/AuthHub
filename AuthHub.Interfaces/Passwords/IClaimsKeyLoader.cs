using System;
using System.Collections.Generic;
using AuthHub.Models.Entities.Passwords;

namespace AuthHub.Interfaces.Passwords
{
    public interface IClaimsKeyLoader
    {
        Task<IEnumerable<ClaimsKey>> GetAsync(Guid authSettingsId);
        Task SaveAsync(IEnumerable<ClaimsKey> item);
    }
}
