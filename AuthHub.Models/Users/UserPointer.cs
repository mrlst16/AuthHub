using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.Models.Users
{
    public record UserPointer(Guid OrganizationID, string AuthSettingsName, string UserName)
    {
        public static implicit operator UserPointer(ValueTuple<Guid, string, string> tuple)
            => new UserPointer(tuple.Item1, tuple.Item2, tuple.Item3);
    }
}
