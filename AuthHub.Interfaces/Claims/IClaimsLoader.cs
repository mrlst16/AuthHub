using System;
using System.Collections.Generic;

namespace AuthHub.Interfaces.Claims
{
    public interface IClaimsLoader
    {
        Task SetClaims(Guid userId, IDictionary<string, string> claims);
    }
}
