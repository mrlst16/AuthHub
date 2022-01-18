using AuthHub.Models.Passwords;
using CommonCore.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Passwords
{
    public interface IClaimsKeyContext: ISR<IEnumerable<ClaimsKey>>
    {
    }
}
