using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthHub.Interfaces.Claims;
using AuthHub.Models.Entities.Claims;
using AuthHub.Models.Requests.Claims;
using AuthHub.Models.Responses.Claims;

namespace AuthHub.BLL.Claims
{
    public class ClaimsService: IClaimsService
    {
        private IClaimsContext _context;

        public ClaimsService(
            IClaimsContext context
            )
        {
            _context = context;
        }

        public async Task<int?> AddClaimsTemplateAsync(
            int organizationId, 
            string name, 
            string description,
            IDictionary<string, string> keysAndDefaultValues
            )
            => await _context.AddClaimsTemplateAsync(organizationId, name, description, keysAndDefaultValues);

        public async Task<IEnumerable<ClaimsTemplateListItem>> GetClaimsTemplateListAsync(int organizationId)
            => (await _context.GetClaimsTemplateListAsync(organizationId))
                .Select(x => new ClaimsTemplateListItem()
                {
                    Name = x.Name,
                    Description = x.Description
                });

        public async Task<ClaimsTemplateResponse> GetClaimsTemplateAsync(int organizationId, string name)
        {
            ClaimsTemplate entity = await _context.GetClaimsTemplateAsync(organizationId, name);
            return new ClaimsTemplateResponse()
            {
                Description = entity.Description,
                Name = entity.Name,
                Keys = entity.ClaimsKeys.Select(x=> new ClaimsKeyResponse()
                {
                    Name = x.Name,
                    Value = x.DefaultValue
                })
            };
        }

        public async Task<bool> AddClaimsKeysAsync(
            int organizationId,
            string templateName,
            IDictionary<string, string> keysAndDefaultValues
        ) => await _context.AddClaimsKeysAsync(organizationId, templateName, keysAndDefaultValues);

        public async Task<bool> DeleteClaimsKeysAsync(
            int organizationId,
            string templateName,
            IEnumerable<string> keyNames
        ) => await _context.DeleteClaimsKeysAsync(organizationId, templateName, keyNames);

        public async Task<bool> AddClaimsAsync(int userId,
            IEnumerable<ClaimRequest> claims)
            => await _context.AddClaimsAsync(userId, claims.ToDictionary(k=> k.Name, v=> v.Value));

        public async Task<bool> RemoveClaimsAsync(int userId, 
            IEnumerable<string> keyNames)
            => await _context.RemoveClaimsAsync(userId, keyNames);

        public async Task<bool> SetClaimsAsync(int userId,
            IEnumerable<ClaimRequest> claims)
            => await _context.SetClaimsAsync(userId, claims.ToDictionary(k => k.Name, v => v.Value));
    }
}