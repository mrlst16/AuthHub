﻿using AuthHub.Models.Enums;
using AuthHub.Models.Verification;
using System;

namespace AuthHub.Interfaces.Verification
{
    public interface IVerificationCodeService
    {
        Task<VerificationCode> GenerateAndSaveUserVerificationCode(Guid userId);
        Task<bool> VerifyAndRecordCode(Guid userid, VerificationTypeEnum type, string code);
    }
}
