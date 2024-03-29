﻿using AuthHub.Models.Entities.Users;
using Common.Models.Entities;
using System;

namespace AuthHub.Models.Entities.Passwords
{
    public class PasswordResetToken : EntityBase<Guid>
    {
        public User User { get; set; }
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string VerificationCode { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
