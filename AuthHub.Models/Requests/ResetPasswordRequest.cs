using AuthHub.Models.Entities.Passwords;

namespace AuthHub.Models.Requests
{
    public class SetPasswordRequest : PasswordResetToken
    {
        public string NewPassword { get; set; }
    }
}
