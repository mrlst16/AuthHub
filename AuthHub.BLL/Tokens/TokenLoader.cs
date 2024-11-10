using AuthHub.Interfaces.Tokens;
using AuthHub.Models.Entities.Tokens;
using System.Threading.Tasks;

namespace AuthHub.BLL.Tokens
{
    public class TokenLoader : ITokenLoader
    {
        public ITokenContext _context { get; set; }

        public TokenLoader(
            ITokenContext context
            )
        {
            _context = context;
        }

        public async Task Create(Token token)
            => await _context.AddAsync(token);
    }
}