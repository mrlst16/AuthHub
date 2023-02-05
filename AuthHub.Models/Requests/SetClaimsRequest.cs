using System.Collections.Generic;

namespace AuthHub.Models.Requests
{
    public class SetClaimsRequest
    {
        public List<KeyValuePair<string, string>> Claims { get; set; }
    }
}
