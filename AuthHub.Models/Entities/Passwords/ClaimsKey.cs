using Common.Models.Entities;
using System;

namespace AuthHub.Models.Entities.Passwords
{
    public class ClaimsKey : EntityBase<int>
    {
        public string Name { get; set; }
        public string DefaultValue { get; set; }
        public int AuthSettingsId { get; set; }
        public bool IsDefault { get; set; }

        public ClaimsKey()
        {
        }

        public ClaimsKey(
            string name,
            int authSettingsId,
            int id
            ) : this()
        {
            Name = name;
            AuthSettingsId = authSettingsId;
            Id = id;
        }
    }
}
