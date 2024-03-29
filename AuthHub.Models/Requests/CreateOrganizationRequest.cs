﻿using AuthHub.Models.Entities.Organizations;
using System.ComponentModel.DataAnnotations;

namespace AuthHub.Models.Requests
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

        public static implicit operator Organization(CreateOrganizationRequest request)
            => new Organization()
            {
                Name = request.Name,
                Email = request.Email
            };

    }
}
