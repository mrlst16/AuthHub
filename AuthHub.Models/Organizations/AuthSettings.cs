using AuthHub.Models.Enums;
using AuthHub.Models.Passwords;
using AuthHub.Models.Users;
using Common.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuthHub.Models.Organizations
{
    public class AuthSettings : EntityBase<Guid>
    {
        public string Name { get; set; }
        public Guid OrganizationID { get; set; }
        public AuthScheme AuthScheme { get; set; }
        public Guid AuthSchemeID { get; set; }
        public int SaltLength { get; set; }
        public int HashLength { get; set; }
        public int Iterations { get; set; }
        [MinLength(8)]
        public string Key { get; set; }
        public string Issuer { get; set; }
        public int ExpirationMinutes { get; set; } = 30;
        public List<ClaimsKey> AvailableClaimsKeys { get; set; } = new List<ClaimsKey>();
        public IEnumerable<User> Users { get; set; } = new List<User>();
        public int PasswordResetTokenExpirationMinutes { get; set; } = 120;
    }
}