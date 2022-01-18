using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Passwords;
using CommonCore.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.BLL.Passwords
{
    public class ClaimsKeyLoader : IClaimsKeyLoader
    {
        private readonly IClaimsKeyContext _context;

        public ClaimsKeyLoader(
            IClaimsKeyContext context
            )
        {
            _context = context;
        }

        public async Task SaveAsync(IEnumerable<ClaimsKey> item)
            => await _context.SaveAsync(item);

        public async Task<IEnumerable<ClaimsKey>> GetAsync(Guid id)
            => await _context.GetAsync(id);
    }
}