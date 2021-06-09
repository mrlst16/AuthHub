using AuthHub.Models.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.Extensions
{
    public static class ModelExtensions
    {
        public static OrganizationSettings GetSettings(this Organization organization, string settingsName)
            => organization.Settings?.FirstOrDefault(x => string.Equals(x.Name, settingsName, StringComparison.InvariantCultureIgnoreCase));
    }
}
