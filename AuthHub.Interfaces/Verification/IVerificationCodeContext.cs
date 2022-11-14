using AuthHub.Models.Enums;
using AuthHub.Models.Verification;
using System;

namespace AuthHub.Interfaces.Verification
{
    public interface IVerificationCodeContext
    {
        Task Create(VerificationCode source);
        Task<VerificationCode> GetLatestByUserIdAndType(Guid userid, VerificationTypeEnum type);
        Task Update(VerificationCode source);
    }
}
