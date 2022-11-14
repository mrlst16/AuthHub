using System;
using System.Threading.Tasks;
using AuthHub.Interfaces.Verification;
using AuthHub.Models.Enums;
using AuthHub.Models.Verification;
using Common.Interfaces.Providers;

namespace AuthHub.BLL.Verification
{
    public class VerificationCodeService : IVerificationCodeService
    {
        private readonly IVerificationCodeLoader _verificationCodeLoader;
        private readonly IDateProvider _dateProvider;

        public VerificationCodeService(
            IVerificationCodeLoader verificationCodeLoader,
            IDateProvider dateProvider
            )
        {
            _verificationCodeLoader = verificationCodeLoader;
            _dateProvider = dateProvider;
        }

        public async Task<VerificationCode> GenerateAndSaveUserVerificationCode(Guid userId)
        {
            var result = new VerificationCode()
            {
                Id = Guid.NewGuid(),
                Type = VerificationTypeEnum.UserEmail,
                Code = GenerateCode(),
                ExpirationDate = _dateProvider.UTCNow.AddMinutes(30)
            };

            await _verificationCodeLoader.Save(result);
            return result;
        }

        public async Task<bool> VerifyAndRecordCode(Guid userid, VerificationTypeEnum type, string code)
        {
            var codeRecord = await _verificationCodeLoader.GetLatestByUserIdAndType(userid, type);
            if (codeRecord == null) return false;

            var currentDateTime = _dateProvider.UTCNow;
            if (codeRecord.ExpirationDate > currentDateTime) return false;

            codeRecord.VerificationDate = currentDateTime;

            await _verificationCodeLoader.Save(codeRecord);

            return codeRecord?.Code == code;
        }

        private string GenerateCode()
            => Guid.NewGuid().ToString().Replace("-", string.Empty);
    }
}
