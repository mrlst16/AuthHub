using Common.Models.Entities;
using System;
using System.Security.Claims;

namespace AuthHub.Models.Passwords
{
    public class ClaimsEntity : EntityBase<int>
    {
        public int ClaimsKeyId { get; set; }
        public int PasswordId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public ClaimsEntity()
        {
        }

        public ClaimsEntity(string key, string value, int claimsKeyId)
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