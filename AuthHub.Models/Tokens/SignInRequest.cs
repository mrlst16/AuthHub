using System.ComponentModel.DataAnnotations;

namespace AuthHub.Models.Tokens
{
    public class SignInRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Range(typeof(bool), "false", "false", ErrorMessage = "There was an error logging in with the provided username and password")]
        public bool DisplaySignInFailure { get; set; } = false;
    }
}