﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthHub.Interfaces.Claims;
using AuthHub.Models.Entities.Claims;
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

        public async Task SetClaims(int userId, IDictionary<string, string> claims)
            => await _context.SetClaims(userId, claims);

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
    }
}