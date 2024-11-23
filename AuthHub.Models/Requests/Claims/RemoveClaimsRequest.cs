using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.Models.Requests.Claims
{
    public class RemoveClaimsRequest
    {
        public int UserId { get; set; }
        public IEnumerable<string> ClaimsKeys { get; set; }
    }
}