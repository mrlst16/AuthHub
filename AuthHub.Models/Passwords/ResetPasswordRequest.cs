using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.Models.Passwords
{
    public class ResetPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public Guid OrganizationId { get; set; }
        public string AuthSettingsName { get; set; }
        public string UserName { get; set; }
    }
}
