using AuthHub.Interfaces.Users;
using AuthHub.Interfaces.Verification;
using AuthHub.Models.Entities.Verification;
using AuthHub.Models.Enums;
using AuthHub.Models.Responses.Verification;
using Common.Interfaces.Providers;
using Common.Interfaces.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AuthHub.BLL.Verification
{
    public class VerificationCodeService : IVerificationCodeService
    {
        private readonly IVerificationCodeLoader _verificationCodeLoader;
        private readonly IUserLoader _userLoader;
        private readonly IDateProvider _dateProvider;
        private readonly IPhoneService _phoneService;
        private readonly IMapper<VerificationCode, VerificationCodeResponse> _verificationCodeResponseMapper;

        public VerificationCodeService(
            IVerificationCodeLoader verificationCodeLoader,
            IUserLoader userLoader,
            IDateProvider dateProvider,
            IPhoneService phoneService,
            IMapper<VerificationCode, VerificationCodeResponse> verificationCodeResponseMapper
            )
        {
            _verificationCodeLoader = verificationCodeLoader;
            _userLoader = userLoader;
            _dateProvider = dateProvider;
            _phoneService = phoneService;
            _verificationCodeResponseMapper = verificationCodeResponseMapper;
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

        public async Task<VerificationCodeResponse> GenerateSendAndSavePhoneLoginCode(string phoneNumber)
        {
            var user = await _userLoader.GetByPhoneNumberAsync(phoneNumber);
            var result = new VerificationCode()
            {
                Id = Guid.NewGuid(),
                Type = VerificationTypeEnum.PhoneLogin,
                Code = Generate6DigitCode(),
                User = user,
                ExpirationDate = _dateProvider.UTCNow.AddMinutes(10)
            };

            await _verificationCodeLoader.Create(result);
            await _phoneService.SendSMSMessage(phoneNumber, result.Code);
            return _verificationCodeResponseMapper.Map(result);
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

        private string Generate6DigitCode()
        {
            string result = string.Empty;
            for (int i = 0; i < 6; i++)
            {
                Thread.Sleep(100);
                Random random = new Random(Guid.NewGuid().GetHashCode());
                int digit = random.Next(0, 9);
                result += digit;
            }
            return result;
        }
    }
}
