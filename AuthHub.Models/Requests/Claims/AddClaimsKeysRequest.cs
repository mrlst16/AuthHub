using System.Collections.Generic;

namespace AuthHub.Models.Requests.Claims
{
    public class AddClaimsKeysRequest
    {
        public string TemplateName { get; set; }
        public IEnumerable<ClaimsKeyRequest> Keys { get; set; }
    }
}
