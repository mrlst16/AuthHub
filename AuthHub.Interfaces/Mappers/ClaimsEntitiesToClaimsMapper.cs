using AuthHub.Models.Passwords;
using Common.Interfaces.Utilities;
using System;
using System.Security.Claims;

namespace AuthHub.Interfaces.Mappers
{
    public class ClaimsEntitiesToClaimsMapper : IMapper<ClaimsEntity, Claim>
    {
        public Claim Map(ClaimsEntity source)
        {
            throw new NotImplementedException();
        }
    }
}
