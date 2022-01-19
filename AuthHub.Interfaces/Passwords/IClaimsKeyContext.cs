using AuthHub.Models.Passwords;
using CommonCore.Interfaces.Repository;
using System.Collections.Generic;

namespace AuthHub.Interfaces.Passwords
{
    public interface IClaimsKeyContext : ISR<IEnumerable<ClaimsKey>>
    {
    }
}
