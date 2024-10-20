using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Entities.Passwords;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<ClaimsKey>> GetAsync(int id)
            => await _context.GetAsync(id);
    }
}