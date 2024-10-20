using System;

namespace AuthHub.Models.Requests
{
    public class ResetPasswordRequest
    {
        public int UserId { get; set; }
        public string NewPassword { get; set; }
        public string VerificationCode { get; set; }
    }
}
