using Common.Models.Entities;
using System;
using System.Security.Claims;

namespace AuthHub.Models.Entities.Passwords
{
    public class ClaimsEntity : EntityBase<Guid>
    {
        public Guid ClaimsKeyId { get; set; }
        public Guid PasswordId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public ClaimsEntity()
        {
        }

        public ClaimsEntity(string key, string value, Guid claimsKeyId)
            : this()
        {
            Key = key;
            Value = value;
            ClaimsKeyId = claimsKeyId;
        }

        public static implicit operator Claim(ClaimsEntity entity)
            => new Claim(entity.Key, entity.Value);
    }

}