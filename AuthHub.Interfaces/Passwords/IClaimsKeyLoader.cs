using AuthHub.Models.Passwords;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Passwords
{
    public interface IClaimsKeyLoader
    {
        Task<IEnumerable<ClaimsKey>> GetAsync(Guid authSettingsId);
        Task SaveAsync(IEnumerable<ClaimsKey> item);
    }
}
