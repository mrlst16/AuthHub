﻿using System;
using AuthHub.Models.Enums;
using AuthHub.Models.Users;
using Common.Models.Entities;

namespace AuthHub.Models.Verification
{
    public class VerificationCode : EntityBase<Guid>
    {
        public User User { get; set; }
        public string Code { get; set; }
        public VerificationType Type { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime? VerificationDate { get; set; } = null;

        public static implicit operator string(VerificationCode code)
            => code.Code;
    }
}