using CommonCore.Repo.Entities;
using System;
using System.Security.Claims;

namespace AuthHub.Models.Passwords
{
    public class ClaimsEntity : EntityBase
    {
        public Guid ClaimsKeyId { get; set; }
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

        public static implicit operator Claim(ClaimsEntity serializableClaim)
            => new Claim(serializableClaim.Key, serializableClaim.Value);
    }

}