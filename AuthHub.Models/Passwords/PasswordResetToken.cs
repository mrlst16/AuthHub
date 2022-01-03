using CommonCore.Repo.Entities;
using System;

namespace AuthHub.Models.Passwords
{
    public class PasswordResetToken : EntityBase
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public Guid OrganizationID { get; set; }
        public string AuthSettingsName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public byte[] Salt { get; set; }
        public byte[] Token { get; set; }
        public bool IsActive { get; set; } = true;
        public byte[] Password { get; set; }
    }
}
