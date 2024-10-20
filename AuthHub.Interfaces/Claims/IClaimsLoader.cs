using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Claims
{
    public interface IClaimsLoader
    {
        Task SetClaims(int userId, IDictionary<string, string> claims);
    }
}
