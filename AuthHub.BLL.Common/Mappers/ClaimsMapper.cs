using AuthHub.Models.Entities.Passwords;
using Common.Interfaces.Utilities;
using System.Security.Claims;

namespace AuthHub.BLL.Common.Mappers
{
    public class ClaimsMapper : IMapper<ClaimsEntity, Claim>
    {
        public Claim Map(ClaimsEntity source)
            => new Claim(source.Key, source.Value);
    }
}
