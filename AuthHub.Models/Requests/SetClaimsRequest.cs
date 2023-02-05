using System.Collections.Generic;

namespace AuthHub.Models.Requests
{
    public class SetClaimsRequest
    {
        public IDictionary<string, string> Claims { get; set; }
    }
}
