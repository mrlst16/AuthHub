using System;

namespace AuthHub.Models.Responses.Verification
{
    public class VerificationCodeResponse
    {
        public string Code { get; set; }
        public DateTime ExpirationDateUTC { get; set; }
    }
}
