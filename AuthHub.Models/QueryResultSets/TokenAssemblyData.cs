using AuthHub.Models.Passwords;
using System;
using System.Collections.Generic;

namespace AuthHub.Models.QueryResultSets
{
    public class TokenAssemblyData
    {
        public List<ClaimsEntity> Claims { get; set; }
        public Guid OrganizationId { get; set; }
        public string Issuer { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string UserName { get; set; }
        public string Key { get; set; }
    }
}