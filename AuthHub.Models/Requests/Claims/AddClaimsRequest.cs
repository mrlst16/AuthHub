using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.Models.Requests.Claims
{
    public class AddClaimsRequest
    {
        public int UserId { get; set; }
        public IDictionary<string, string> Claims { get; set; }
    }
}
