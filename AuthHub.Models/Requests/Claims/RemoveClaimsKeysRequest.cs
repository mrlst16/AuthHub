using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.Models.Requests.Claims
{
    public class RemoveClaimsKeysRequest
    {
        public string TemplateName { get; set; }
        public IEnumerable<string> KeyNames { get; set; }
    }
}
