using System;

namespace AuthHub.Models.Requests
{
    public class ResetOrganizationPasswordRequest
    {
        public int OrganizationId { get; set; }
        public string AuthSettingsName { get; set; }
        public string UserName { get; set; }
    }
}
