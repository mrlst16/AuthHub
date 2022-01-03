using AuthHub.Models.Passwords;
using CommonCore.Repo.Entities;
using System;

namespace AuthHub.Models.Users
{
    public class User : EntityBase
    {
        public Guid AuthSettingsId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Password Password { get; set; }
    }
}
