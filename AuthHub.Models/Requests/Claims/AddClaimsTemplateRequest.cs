using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.Models.Requests.Claims
{
    public class AddClaimsTemplateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IDictionary<string, string> Keys { get; set; }
    }
}