using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AuthHub.Models.Entities.Passwords;
using Common.Interfaces.Utilities;

namespace AuthHub.BLL.Common.Mappers
{
    public class ClaimsMapper : IMapper<ClaimsEntity, Claim>
    {
        public Claim Map(ClaimsEntity source)
            => new Claim(source.Key, source.Value);
    }
}
