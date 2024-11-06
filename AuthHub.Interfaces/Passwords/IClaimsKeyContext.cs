using AuthHub.Models.Entities.Claims;
using System;
using System.Collections.Generic;

namespace AuthHub.Interfaces.Passwords
{
    public interface IClaimsKeyContext
    {
        Task SaveAsync(IEnumerable<ClaimsKey> item);
    }
}
