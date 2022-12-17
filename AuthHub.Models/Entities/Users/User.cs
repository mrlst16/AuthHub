using AuthHub.Models.Entities.Organizations;
using AuthHub.Models.Entities.Passwords;
using AuthHub.Models.Entities.Tokens;
using AuthHub.Models.Entities.Verification;
using Common.Models.Entities;
using System;
using System.Collections.Generic;

namespace AuthHub.Models.Entities.Users
{
    public class User : EntityBase<Guid>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Password Password { get; set; } = new Password();
        public IEnumerable<VerificationCode> VerificationCodes { get; set; } = new List<VerificationCode>();
        public List<Token> Tokens { get; set; } = new List<Token>();
        public AuthSettings AuthSettings { get; set; }
        public Guid AuthSettingsId { get; set; }
    }
}
