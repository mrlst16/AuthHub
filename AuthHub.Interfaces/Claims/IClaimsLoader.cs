using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthHub.Models.Entities.Claims;

namespace AuthHub.Interfaces.Claims
{
    public interface IClaimsLoader
    {
        Task<IEnumerable<ClaimsEntity>> GetClaimsFromTemplate(int organizationId, string name);
    }
}
