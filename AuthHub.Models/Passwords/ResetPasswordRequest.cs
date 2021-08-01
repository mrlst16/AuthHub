using System;
using System.ComponentModel.DataAnnotations;

namespace AuthHub.Models.Passwords
{
    public class ResetPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public Guid OrganizationId { get; set; }
        public string AuthSettingsName { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
