namespace AuthHub.Models.Passwords
{
    public class ResetPasswordRequest : PasswordResetToken
    {
        public string NewPassword { get; set; }
    }
}
