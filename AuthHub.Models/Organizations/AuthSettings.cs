using AuthHub.Models.Entities.Enums;
using AuthHub.Models.Entities.Users;
using Common.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AuthHub.Models.Entities.Passwords;

namespace AuthHub.Models.Organizations
{
    public class AuthSettings : EntityBase<int>
    {
        public string Name { get; set; }
        public int OrganizationID { get; set; }
        public AuthScheme AuthScheme { get; set; }
        public int AuthSchemeID { get; set; }
        public int SaltLength { get; set; }
        public int HashLength { get; set; }
        public int Iterations { get; set; }
        [MinLength(8)]
        public string Key { get; set; }
        public string Issuer { get; set; }
        public int ExpirationMinutes { get; set; } = 30;
        public List<ClaimsKey> AvailableClaimsKeys { get; set; } = new List<ClaimsKey>();
        public int PasswordResetTokenExpirationMinutes { get; set; } = 120;
        public List<User> Users { get; set; } = new List<User>();
    }
}