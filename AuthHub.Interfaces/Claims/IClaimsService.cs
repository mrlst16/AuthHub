using AuthHub.Models.Responses.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Claims
{
    public interface IClaimsService
    {
        Task SetClaims(int userId, IDictionary<string, string> claims);
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