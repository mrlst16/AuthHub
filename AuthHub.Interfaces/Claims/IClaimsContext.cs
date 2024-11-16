using System.Collections.Generic;
using AuthHub.Models.Entities.Claims;

namespace AuthHub.Interfaces.Claims
{
    public interface IClaimsContext
    {
        Task<bool> AddClaimsAsync(
            int userId,
            IDictionary<string, string> keysAndValues
        );

        Task<bool> RemoveClaimsAsync(
            int userId,
            IEnumerable<string> keyNames
        );

        Task<bool> SetClaimsAsync(
            int userId,
            IDictionary<string, string> keysAndValues
        );

        Task<IEnumerable<ClaimsTemplate>> GetClaimsTemplateListAsync(int organizationId);

        Task<ClaimsTemplate> GetClaimsTemplateAsync(int organizationId, string name);

        Task<int?> AddClaimsTemplateAsync(
            int organizationId,
            string name,
            string description,
            IDictionary<string, string> keysAndDefaultValues
        );

        Task<bool> AddClaimsKeysAsync(int organizationId, string templateName, IDictionary<string, string> keysAndDefaultValues);

        Task<bool> DeleteClaimsKeysAsync(int organizationId, string templateName, IEnumerable<string> keyNames);
    }
}