using AuthHub.Models.Organizations;

namespace AuthHub.BLL.Common.Extensions
{
    public static class ModelExtensions
    {
        public static AuthSettings? GetSettings(this Organization organization, string settingsName)
            => organization?.Settings?.FirstOrDefault(x => string.Equals(x?.Name, settingsName, StringComparison.InvariantCultureIgnoreCase));
    }
}
