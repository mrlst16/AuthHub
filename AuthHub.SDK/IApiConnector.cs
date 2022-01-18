using AuthHub.Models.Tokens;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthHub.SDK
{
    public interface IApiConnector
    {
        Task<Token> GetTokenFromLocalStorage();
        Task<TOut> Post<TIn, TOut>(string endpoint, TIn val, IDictionary<string, string> queryParams = null, IDictionary<string, string> headers = null);
        Task<TOut> Patch<TIn, TOut>(string endpoint, TIn val, IDictionary<string, string> queryParams = null, IDictionary<string, string> headers = null);
        Task<TOut> Put<TIn, TOut>(string endpoint, TIn val, IDictionary<string, string> queryParams = null, IDictionary<string, string> headers = null);
        Task<T> Get<T>(string endpoint, IDictionary<string, string> queryParams = null, IDictionary<string, string> headers = null);
    }
}