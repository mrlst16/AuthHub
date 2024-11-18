using System.Collections.Generic;

namespace AuthHub.Models.Requests.Claims
{
    public class AddClaimsKeysRequest
    {
        public string TemplateName { get; set; }
        public IEnumerable<ClaimRequest> Keys { get; set; }
    }
}
