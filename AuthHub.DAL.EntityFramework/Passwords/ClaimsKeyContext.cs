using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Passwords;

namespace AuthHub.DAL.EntityFramework.Passwords
{
    public class ClaimsKeyContext : IClaimsKeyContext
    {
        public Task SaveAsync(IEnumerable<ClaimsKey> item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClaimsKey>> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
