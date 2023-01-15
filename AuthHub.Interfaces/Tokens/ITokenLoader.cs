using AuthHub.Models.Entities.Tokens;

namespace AuthHub.Interfaces.Tokens
{
    public interface ITokenLoader
    {
        Task Create(Token token);
    }
}