using System;
using System.Collections.Generic;

namespace AuthHub.Models.Requests.Claims
{
    public class SetClaimsRequest
    {
        public int UserId { get; set; }
        public IEnumerable<ClaimRequest> Claims { get; set; }
    }
}