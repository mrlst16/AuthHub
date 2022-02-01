using AuthHub.Models.Passwords;
using CommonCore.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Passwords
{
    public interface IClaimsKeyService
    {
        Task<IEnumerable<ClaimsKey>> GetAsync(Guid authSettingsId);
    }
}
