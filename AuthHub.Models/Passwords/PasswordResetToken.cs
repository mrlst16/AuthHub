﻿using Common.Models.Entities;
using System;

namespace AuthHub.Models.Passwords
{
    public class PasswordResetToken : EntityBase<int>
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string VerificationCode { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
