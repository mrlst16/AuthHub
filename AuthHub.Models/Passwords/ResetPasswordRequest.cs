namespace AuthHub.Models.Passwords
{
    public class SetPasswordRequest : PasswordResetToken
    {
        public string NewPassword { get; set; }
    }
}
