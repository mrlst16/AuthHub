using System;
using System.Threading.Tasks;
using AuthHub.Interfaces.Verification;
using AuthHub.Models.Enums;
using AuthHub.Models.Verification;

namespace AuthHub.BLL.Verification
{
    public class VerificationCodeLoader : IVerificationCodeLoader
    {

        private readonly IVerificationCodeContext _context;

        public VerificationCodeLoader(
            IVerificationCodeContext context
            )
        {
            _context = context;
        }

        public async Task Save(VerificationCode source)
            => await _context.Save(source);

        public async Task<VerificationCode> GetLatestByUserIdAndType(Guid userid, VerificationType type)
            => await _context.GetLatestByUserIdAndType(userid, type);
    }
}
