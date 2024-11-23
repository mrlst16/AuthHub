using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.Models.Responses.Claims
{
    public class ClaimsTemplateResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<ClaimsKeyResponse> Keys { get; set; }
    }
}
