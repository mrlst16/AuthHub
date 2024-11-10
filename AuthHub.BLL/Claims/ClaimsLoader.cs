using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthHub.BLL.Common.Exceptions;
using AuthHub.Interfaces.Claims;
using AuthHub.Models.Entities.Claims;

namespace AuthHub.BLL.Claims
{
    public class ClaimsLoader : IClaimsLoader
    {
        private readonly IClaimsContext _context;

        public ClaimsLoader(
            IClaimsContext context
            )
        {
            _context = context;
        }

        public async Task<IEnumerable<ClaimsEntity>> GetClaimsFromTemplate(int organizationId, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return new List<ClaimsEntity>();
            ClaimsTemplate template = await _context.GetClaimsTemplateAsync(organizationId, name);
            if (template == null)
                throw new NotFoundException($"Claims template ${name} does not exist");

            return template.ClaimsKeys.Select(x => new ClaimsEntity()
            {
                ClaimsKeyId = x.Id,
                Key = x.Name,
                Value = x.DefaultValue
            });
        }
    }
}
