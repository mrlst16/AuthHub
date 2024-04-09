using AuthHub.Models.Entities.Passwords;
using System;
using System.Collections.Generic;

namespace AuthHub.Interfaces.Claims
{
    public interface IClaimsRepository
    {
        Task SetClaims(Guid userId, IEnumerable<ClaimsKey> claims);
        Task<IEnumerable<ClaimsKey>> Translate(IEnumerable<string> claimsKeyNames);
    }
}