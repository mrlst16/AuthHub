using System.ComponentModel.DataAnnotations;

namespace AuthHub.Models.Organizations
{
    public class CreateOrganizationRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        [MinLength(8)]
        public string ConfirmPassword { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
