using System.ComponentModel.DataAnnotations;

namespace AuthHub.Models.Tokens
{
    public class SignInRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}