using System;
using AuthHub.Models.Enums;
using AuthHub.Models.Verification;

namespace AuthHub.Interfaces.Verification
{
    public interface IVerificationCodeLoader
    {
        Task Save(VerificationCode source);
        Task<VerificationCode> GetLatestByUserIdAndType(Guid userid, VerificationType type);
    }
}
