using AuthHub.Models.Entities.Enums;
using Common.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace AuthHub.Models.Entities.Organizations
{
    public class AuthSettings : EntityBase<int>
    {
        public int OrganizationID { get; set; }
        public AuthScheme AuthScheme { get; set; }
        public int AuthSchemeID { get; set; }
        public int SaltLength { get; set; }
        public int HashLength { get; set; }
        public int Iterations { get; set; }
        [MinLength(8)]
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpirationMinutes { get; set; } = 30;
        public string PasswordResetUrl { get; set; }
        public Organization Organization { get; set; }
    }
}