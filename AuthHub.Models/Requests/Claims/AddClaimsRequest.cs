﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.Models.Requests.Claims
{
    public class AddClaimsRequest
    {
        public int UserId { get; set; }
        public IEnumerable<ClaimRequest> Claims { get; set; }
    }
}
