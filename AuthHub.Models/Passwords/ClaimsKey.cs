using CommonCore.Repo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.Models.Passwords
{
    public class ClaimsKey : EntityBase
    {
        public string Name { get; set; }
        public Guid AuthSettingsId { get; set; }

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
            ID = id;
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
