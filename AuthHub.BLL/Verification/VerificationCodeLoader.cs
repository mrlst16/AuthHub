using AuthHub.Interfaces.Verification;
using AuthHub.Models.Entities.Enums;
using AuthHub.Models.Entities.Verification;
using System;
using System.Threading.Tasks;

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

        public async Task Create(VerificationCode source)
            => await _context.Create(source);

        public async Task Update(VerificationCode source)
            => await _context.Update(source);

        public async Task<VerificationCode> GetLatestByUserIdAndType(int userid, VerificationType type)
            => await _context.GetLatestByUserIdAndType(userid, type);

        
    }
}
