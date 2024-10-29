using Common.Models.Entities;
using System;
using System.Collections.Generic;
using AuthHub.Models.Entities.Passwords;

namespace AuthHub.Models.Entities.Organizations
{
    public class Organization : EntityBase<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<AuthSettings> Settings { get; set; } = new List<AuthSettings>();
        public APIKeyAndSecretHash APIKeyAndSecretHash { get; set; }
    }
}
