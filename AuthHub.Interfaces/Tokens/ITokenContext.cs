using AuthHub.Models.Entities.Tokens;

namespace AuthHub.Interfaces.Tokens
{
    public interface ITokenContext
    {
        Task Create(Token token);
    }
}
