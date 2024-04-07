using AuthHub.Models.Entities.Verification;
using AuthHub.Models.Enums;
using System;
using AuthHub.Models.Responses.Verification;

namespace AuthHub.Interfaces.Verification
{
    public interface IVerificationCodeService
    {
        Task<VerificationCode> GenerateAndSaveUserVerificationCode(Guid userId);
        Task<bool> VerifyAndRecordCode(Guid userid, VerificationTypeEnum type, string code);
        Task<VerificationCodeResponse> GenerateSendAndSavePhoneLoginCode(string phoneNumber);
    }
}
