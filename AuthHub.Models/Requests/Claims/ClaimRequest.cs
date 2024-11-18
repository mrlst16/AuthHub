using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.Models.Requests.Claims
{
    public class ClaimRequest
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
