using CommonCore.Models.Repo.Entities;
using System;

namespace AuthHub.Models.Passwords
{
    public class PasswordResetToken : EntityBase
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
