using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AuthHub.Models.Passwords;
using Common.Interfaces.Utilities;

namespace AuthHub.Interfaces.Mappers
{
    public class ClaimsEntitiesToClaimsMapper: IMapper<ClaimsEntity, Claim>
    {
        public Claim Map(ClaimsEntity source)
        {
            throw new NotImplementedException();
        }
    }
}
