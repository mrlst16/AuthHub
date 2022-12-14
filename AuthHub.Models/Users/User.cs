﻿using AuthHub.Models.Organizations;
using AuthHub.Models.Passwords;
using AuthHub.Models.Verification;
using Common.Models.Entities;
using System;
using System.Collections.Generic;

namespace AuthHub.Models.Users
{
    public class User : EntityBase<Guid>
    {
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
