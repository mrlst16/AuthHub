using System.Collections.Generic;

namespace AuthHub.Models.Requests.Claims
{
    public class AddClaimsTemplateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IDictionary<string, string> Keys { get; set; }
    }
}