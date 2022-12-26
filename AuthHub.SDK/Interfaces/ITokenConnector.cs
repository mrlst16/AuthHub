using AuthHub.Models.Entities.Tokens;

namespace AuthHub.SDK.Interfaces
{
    public interface ITokenConnector
    {
        Task<Token> GetJWTTokenAsnyc(string username, string password);
    }
}
