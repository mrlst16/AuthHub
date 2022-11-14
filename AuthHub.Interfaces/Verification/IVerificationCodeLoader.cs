using AuthHub.Models.Enums;
using AuthHub.Models.Verification;
using System;

namespace AuthHub.Interfaces.Verification
{
    public interface IVerificationCodeLoader
    {
        Task Create(VerificationCode source);
        Task Update(VerificationCode source);
        Task<VerificationCode> GetLatestByUserIdAndType(Guid userid, VerificationType type);
    }
}
