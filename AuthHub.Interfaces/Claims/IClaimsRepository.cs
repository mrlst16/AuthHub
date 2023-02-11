using System;
using System.Collections.Generic;
using AuthHub.Models.Entities.Passwords;

namespace AuthHub.Interfaces.Claims
{
    public interface IClaimsRepository
    {
        Task SetClaims(Guid userId, IEnumerable<ClaimsKey> claims);
        Task<IEnumerable<ClaimsKey>> Translate(IEnumerable<string> claimsKeyNames);
    }
}