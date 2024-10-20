using AuthHub.Models.Entities.Users;
using Common.Models.Entities;
using System;

namespace AuthHub.Models.Entities.Tokens
{
    public class Token : EntityBase<int>
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string Value { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpirationDate { get; set; } = DateTime.MaxValue;

        public Token()
        {
        }
    }
}