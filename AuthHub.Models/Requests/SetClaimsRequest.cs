using System;
using System.Collections.Generic;

namespace AuthHub.Models.Requests
{
    public class SetClaimsRequest
    {
        public int UserId { get; set; }
        public List<KeyValuePair<string, string>> Claims { get; set; }
    }
}
