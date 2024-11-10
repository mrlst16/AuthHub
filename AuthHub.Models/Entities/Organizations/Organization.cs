using Common.Models.Entities;
using System;
using System.Collections.Generic;
using AuthHub.Models.Entities.Claims;
using AuthHub.Models.Entities.Passwords;
using AuthHub.Models.Entities.Tokens;
using AuthHub.Models.Entities.Users;

namespace AuthHub.Models.Entities.Organizations
{
    public class Organization : EntityBase<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<ClaimsTemplate> ClaimsTemplates { get; set; }
        public AuthSettings Settings { get; set; }
        public List<APIKeyAndSecretHash> APIKeyAndSecretHash { get; set; }
        public OrganizationToken Token { get; set; }
        public List<User> Users { get; set; }
    }
}
