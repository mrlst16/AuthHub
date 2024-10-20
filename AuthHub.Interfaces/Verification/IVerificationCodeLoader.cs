using AuthHub.Models.Entities.Enums;
using AuthHub.Models.Entities.Verification;
using System;

namespace AuthHub.Interfaces.Verification
{
    public interface IVerificationCodeLoader
    {
        Task Create(VerificationCode source);
        Task Update(VerificationCode source);
        Task<VerificationCode> GetLatestByUserIdAndType(int userid, VerificationType type);
    }
}
