using System;
using System.Collections.Generic;

namespace AuthHub.Interfaces.Claims
{
    public interface IClaimsContext
    {
        Task SetClaims(Guid userId, IDictionary<string, string> claims);
    }
}