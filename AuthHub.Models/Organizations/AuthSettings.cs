using AuthHub.Models.Enums;
using AuthHub.Models.Users;
using CommonCore.Repo.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuthHub.Models.Organizations
{
    public class AuthSettings : EntityBase
    {
        public string Name { get; set; }
        public Guid OrganizationID { get; set; }
        public AuthSchemeEnum AuthScheme { get; set; }
        public int SaltLength { get; set; }
        public int HashLength { get; set; }
        public int Iterations { get; set; }
        [MinLength(8)]
        public string Key { get; set; }
        public string Issuer { get; set; }
        public int ExpirationMinutes { get; set; } = 30;
        public List<string> ClaimsKeys { get; set; } = new List<string>();
        public List<User> Users { get; set; } = new List<User>();
    }
}