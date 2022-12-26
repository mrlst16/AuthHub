using AuthHub.Interfaces.Tokens;
using AuthHub.Models.Entities.Tokens;

namespace AuthHub.DAL.EntityFramework.Tokens
{
    public class TokenContext : ITokenContext
    {
        private readonly AuthHubContext _context;

        public TokenContext(
            AuthHubContext context
            )
        {
            _context = context;
        }

        public async Task Create(Token token)
        {
            _context.Tokens.Add(token);
            await _context.SaveChangesAsync();
        }
    }
}
