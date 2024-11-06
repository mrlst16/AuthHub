using System.Collections.Generic;
using AuthHub.Models.Entities.Organizations;
using Common.Models.Entities;

namespace AuthHub.Models.Entities.Claims
{
    public class ClaimsTemplate: EntityBase<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public List<ClaimsKey> ClaimsKeys { get; set; }
    }
}
