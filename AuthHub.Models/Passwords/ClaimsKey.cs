using Common.Models.Entities;
using System;

namespace AuthHub.Models.Passwords
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
            int authSettingsId
            )
        {
        }

        public static implicit operator ClaimsKey(ValueTuple<string, int> nameAndFkAuthSettings)
            => new ClaimsKey(nameAndFkAuthSettings.Item1, nameAndFkAuthSettings.Item2);
    }
}
