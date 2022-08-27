using AuthHub.Models.Passwords;

namespace AuthHub.Models.Requests
{
    public class SetPasswordRequest : PasswordResetToken
    {
        public string NewPassword { get; set; }
    }
}
