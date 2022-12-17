using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Entities.Passwords;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthHub.BLL.Passwords
{
    public class ClaimsKeyService : IClaimsKeyService
    {
        private readonly IClaimsKeyLoader _loader;

        public ClaimsKeyService(
            IClaimsKeyLoader loader
            )
        {
            _loader = loader;
        }


        public async Task<IEnumerable<ClaimsKey>> GetAsync(Guid id)
            => await _loader.GetAsync(id);

        public async Task SaveAsync(IEnumerable<ClaimsKey> item)
            => await _loader.SaveAsync(item);
    }
}
