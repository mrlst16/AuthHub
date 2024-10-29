using Common.Models.Entities;
using System;
using System.Collections.Generic;
using AuthHub.Models.Entities.Organizations;

namespace AuthHub.Models.Entities.Passwords
{
    public class Password : EntityBase<int>
    {
        public int UserId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] Salt { get; set; }
        public Organization Organization { get; set; }
        public List<ClaimsEntity> Claims { get; set; } = new List<ClaimsEntity>();
    }

    public class PasswordArchive : EntityBase<int>
    {
        public int UserId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] Salt { get; set; }

        public static implicit operator PasswordArchive(Password source)
            => new PasswordArchive()
            {
                PasswordHash = source.PasswordHash,
                Salt = source.Salt,
                UserId = source.UserId
            };
    }
}
