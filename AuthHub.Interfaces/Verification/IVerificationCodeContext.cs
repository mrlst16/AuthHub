using AuthHub.Models.Entities.Verification;
using AuthHub.Models.Enums;
using System;

namespace AuthHub.Interfaces.Verification
{
    public interface IVerificationCodeContext
    {
        Task Create(VerificationCode source);
        Task<VerificationCode> GetLatestByUserIdAndType(int userid, VerificationTypeEnum type);
        Task Update(VerificationCode source);
    }
}
