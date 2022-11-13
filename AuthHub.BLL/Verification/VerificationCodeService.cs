using System;
using System.Threading.Tasks;
using AuthHub.Interfaces.Verification;

namespace AuthHub.BLL.Verification
{
    public class VerificationCodeService : IVerificationCodeService
    {
        public async Task<string> GenerateAndSaveUserVerificationCode()
        {
            var result = Guid.NewGuid().ToString().Replace("-", string.Empty);

            return result;
        }
    }
}
