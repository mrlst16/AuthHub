using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthHub.Models.Requests;

namespace AuthHub.SDK.Interfaces
{
    public interface IClaimsConnector
    {
        Task SetClaims(SetClaimsRequest request);
    }
}
