using AuthHub.Models.Responses.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthHub.Models.Requests.Claims;

namespace AuthHub.Interfaces.Claims
{
    public interface IClaimsService
    {
        Task<bool> AddClaimsAsync(
            int userId,
            IEnumerable<ClaimRequest> claims);

        Task<bool> RemoveClaimsAsync(
            int userId,
            IEnumerable<string> keyNames
        );

        Task<bool> SetClaimsAsync(
            int userId,
            IEnumerable<ClaimRequest> claims
        );

        Task<int?> AddClaimsTemplateAsync(
            int organizationId,
            string name,
            string description,
            IDictionary<string, string> keysAndDefaultValues
        );

        Task<ClaimsTemplateResponse> GetClaimsTemplateAsync(int organizationId, string name);
        
        Task<IEnumerable<ClaimsTemplateListItem>> GetClaimsTemplateListAsync(int organizationId);

        Task<bool> AddClaimsKeysAsync(
            int organizationId,
            string templateName,
            IDictionary<string, string> keysAndDefaultValues
        );

        Task<bool> DeleteClaimsKeysAsync(int organizationId, string templateName, IEnumerable<string> keyNames);
    }
}