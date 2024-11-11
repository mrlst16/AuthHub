using AuthHub.Interfaces.Tokens;
using AuthHub.Models.Entities.Tokens;
using AuthHub.Models.Entities.Users;
using Microsoft.EntityFrameworkCore;

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

        public async Task AddAsync(Token token)
        {
            _context.Tokens.Add(token);
            _context.SaveChanges();
        }
    }
}
