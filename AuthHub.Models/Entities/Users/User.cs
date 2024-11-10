using AuthHub.Models.Entities.Organizations;
using AuthHub.Models.Entities.Passwords;
using AuthHub.Models.Entities.Tokens;
using AuthHub.Models.Entities.Verification;
using Common.Models.Entities;
using System.Collections.Generic;
using AuthHub.Models.Entities.Claims;

namespace AuthHub.Models.Entities.Users
{
    public class User : EntityBase<int>
    {
        public int OrganizationId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        //Data is supposed to be a json representation of any data about a user that the client wants to store
        public string Data { get; set; }
        public Password Password { get; set; } = new Password();
        public IEnumerable<VerificationCode> VerificationCodes { get; set; } = new List<VerificationCode>();
        public List<ClaimsEntity> Claims { get; set; } = new List<ClaimsEntity>();
        public List<Token> Tokens { get; set; } = new List<Token>();
        public List<PasswordArchive> PasswordArchives { get; set; } = new List<PasswordArchive>();
        public List<PasswordResetToken> PasswordResetTokens { get; set; } = new List<PasswordResetToken>();
        public Organization Organization { get; set; }
    }
}
