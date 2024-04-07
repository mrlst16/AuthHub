using AuthHub.Models.Entities.Verification;
using AuthHub.Models.Responses.Verification;
using Common.Interfaces.Utilities;

namespace AuthHub.BLL.Common.Mappers
{
    public class VerificationCodeResponseMapper : IMapper<VerificationCode, VerificationCodeResponse>
    {
        public VerificationCodeResponse Map(VerificationCode source)
            => new VerificationCodeResponse()
            {
                Code = source.Code,
                ExpirationDateUTC = source.ExpirationDate
            };
    }
}
