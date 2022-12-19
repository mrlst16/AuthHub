using Common.Models.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace AuthHub.Models.Passwords
{
    public class Password : EntityBase<Guid>
    {
        public Guid UserId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] Salt { get; set; }
        public List<ClaimsEntity> Claims { get; set; } = new List<ClaimsEntity>();
        public DateTime ExpirationDate { get; set; }

        public List<Claim> GetClaims()
        {
            List<Claim> result = new List<Claim>();
            foreach (var serializableClaim in Claims)
            {
                result.Add(serializableClaim);
            }
            return result;
        }
    }
}
