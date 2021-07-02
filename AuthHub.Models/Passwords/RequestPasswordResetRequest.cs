using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.Models.Passwords
{
    public class RequestPasswordResetRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
