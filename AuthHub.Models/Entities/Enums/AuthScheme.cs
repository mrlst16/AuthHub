using AuthHub.Models.Enums;
using Common.Models.Entities;
using System;

namespace AuthHub.Models.Entities.Enums
{
    public class AuthScheme : EntityBase<int>
    {
        public string Name { get; set; }
        public AuthSchemeEnum Value { get; set; }

        public AuthScheme()
        {
        }

        internal AuthScheme(AuthSchemeEnum source)
            : this()
        {
            Value = source;
            Name = Enum.GetName(source);
        }

        public static implicit operator AuthSchemeEnum(AuthScheme source)
            => source.Value;

        public static implicit operator AuthScheme(AuthSchemeEnum source)
            => new AuthScheme(source);

        public static explicit operator int(AuthScheme source)
            => (int)source.Value;
    }
}
