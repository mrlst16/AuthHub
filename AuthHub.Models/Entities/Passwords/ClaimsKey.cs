using Common.Models.Entities;
using System;

namespace AuthHub.Models.Entities.Passwords
{
    public class ClaimsKey : EntityBase<Guid>
    {
        public string Name { get; set; }
        public string DefaultValue { get; set; }
        public Guid AuthSettingsId { get; set; }
        public bool IsDefault { get; set; }

        public ClaimsKey()
        {
        }

        public ClaimsKey(
            string name,
            Guid authSettingsId,
            Guid id
            ) : this()
        {
            Name = name;
            AuthSettingsId = authSettingsId;
            Id = id;
        }

        public ClaimsKey(
            string name,
            Guid authSettingsId
            ) : this(name, authSettingsId, Guid.NewGuid())
        {
        }

        public static implicit operator ClaimsKey(ValueTuple<string, Guid> nameAndFkAuthSettings)
            => new ClaimsKey(nameAndFkAuthSettings.Item1, nameAndFkAuthSettings.Item2);
    }
}
