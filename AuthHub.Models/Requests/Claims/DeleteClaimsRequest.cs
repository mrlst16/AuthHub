using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.Models.Requests.Claims
{
    public class DeleteClaimsRequest
    {
        public int UserId { get; set; }
        public IEnumerable<string> ClaimsKeys { get; set; }
    }
}
