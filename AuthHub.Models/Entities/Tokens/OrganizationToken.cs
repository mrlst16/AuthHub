using System;
using System.Collections.Generic;
using System.Linq;
using AuthHub.Models.Entities.Organizations;
using Common.Models.Entities;

namespace AuthHub.Models.Entities.Tokens
{
    public class OrganizationToken : EntityBase<int>
    {
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public string Value { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpirationDate { get; set; } = DateTime.MaxValue;
    }
}
