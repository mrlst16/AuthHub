﻿using System;

namespace AuthHub.Models.Users
{
    public class CreateUserRequest
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Guid AuthSettingsId { get; set; }
    }
}
