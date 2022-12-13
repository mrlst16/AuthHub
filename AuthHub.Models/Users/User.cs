using AuthHub.Models.Passwords;
using AuthHub.Models.Verification;
using Common.Models.Entities;
using System;
using System.Collections.Generic;
using AuthHub.Models.Organizations;

namespace AuthHub.Models.Users
{
    public class User : EntityBase<Guid>
    {
        public Guid UsersOrganizationId { get; set; }

        private bool? _isOrganization;
        public bool? IsOrganization
        {
            get => _isOrganization ??= (UsersOrganizationId != Guid.Empty);
            set => _isOrganization = value;
        }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Password Password { get; set; } = new Password();
        public IEnumerable<VerificationCode> VerificationCodes { get; set; } = new List<VerificationCode>();
        public AuthSettings AuthSettings { get; set; }
        public Guid AuthSettingsId { get; set; }
    }
}
