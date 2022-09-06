using AuthHub.Models.Passwords;
using System;
using System.Collections.Generic;

namespace AuthHub.Interfaces.Passwords
{
    public interface IClaimsKeyContext
    {
        Task SaveAsync(IEnumerable<ClaimsKey> item);
        Task<IEnumerable<ClaimsKey>> GetAsync(Guid id);
    }
}
