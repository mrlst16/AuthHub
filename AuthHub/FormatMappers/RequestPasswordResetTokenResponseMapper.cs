using AuthHub.Api.Responses;
using AuthHub.Models.Entities.Passwords;
using Common.Interfaces.Utilities;

namespace AuthHub.Api.FormatMappers
{
    public class RequestPasswordResetTokenResponseMapper : IMapper<PasswordResetToken, RequestPasswordResetTokenResponse>
    {
        public RequestPasswordResetTokenResponse Map(PasswordResetToken source)
            => new RequestPasswordResetTokenResponse()
            {
                VerificationCode = source.VerificationCode
            };
    }
}
