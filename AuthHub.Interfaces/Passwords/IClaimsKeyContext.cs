using System;
using System.Collections.Generic;
using AuthHub.Models.Entities.Passwords;

namespace AuthHub.Interfaces.Passwords
{
    public interface IClaimsKeyContext
    {
        Task SaveAsync(IEnumerable<ClaimsKey> item);
        Task<IEnumerable<ClaimsKey>> GetAsync(Guid id);
    }
}
