using AuthHub.Interfaces.Users;
using AuthHub.Interfaces.Verification;
using AuthHub.Models.Entities.Verification;
using AuthHub.Models.Enums;
using Common.Interfaces.Providers;
using System;
using System.Threading.Tasks;

namespace AuthHub.BLL.Verification
{
    public class VerificationCodeService : IVerificationCodeService
    {
        private readonly IVerificationCodeLoader _verificationCodeLoader;
        private readonly IUserLoader _userLoader;
        private readonly IDateProvider _dateProvider;

        public VerificationCodeService(
            IVerificationCodeLoader verificationCodeLoader,
            IUserLoader userLoader,
            IDateProvider dateProvider
            )
        {
            _verificationCodeLoader = verificationCodeLoader;
            _userLoader = userLoader;
            _dateProvider = dateProvider;
        }

        public async Task<VerificationCode> GenerateAndSaveUserVerificationCode(Guid userId)
        {
            var user = await _userLoader.GetAsync(userId, false);
            var result = new VerificationCode()
            {
                Id = Guid.NewGuid(),
                Type = VerificationTypeEnum.UserEmail,
                Code = GenerateCode(),
                User = user,
                ExpirationDate = _dateProvider.UTCNow.AddMinutes(30)
            };

            await _verificationCodeLoader.Create(result);
            return result;
        }

        public async Task<bool> VerifyAndRecordCode(Guid userid, VerificationTypeEnum type, string code)
        {
            var codeRecord = await _verificationCodeLoader.GetLatestByUserIdAndType(userid, type);
            if (codeRecord == null) return false;

            var currentDateTime = _dateProvider.UTCNow;
            if (codeRecord.ExpirationDate < currentDateTime) return false;

            codeRecord.VerificationDate = currentDateTime;

            await _verificationCodeLoader.Update(codeRecord);

            return codeRecord?.Code == code;
        }

        private string GenerateCode()
            => Guid.NewGuid().ToString().Replace("-", string.Empty);
    }
}
