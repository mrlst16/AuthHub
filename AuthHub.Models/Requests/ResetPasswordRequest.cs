using System;

namespace AuthHub.Models.Requests
{
    public class ResetPasswordRequest
    {
        public Guid UserId { get; set; }
        public string NewPassword { get; set; }
        public string VerificationCode { get; set; }
    }
}
