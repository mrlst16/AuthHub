using AuthHub.Models.Tokens;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AuthHub.SDK
{
    public interface IApiConnector
    {
        Task<Token> GetTokenFromLocalStorage(string fromPage = "");
        Task<TOut> Post<TIn, TOut>(string endpoint, TIn val, IDictionary<string, string> queryParams = null, IDictionary<string, string> headers = null);
        Task Post<TIn>(string endpoint, TIn val, IDictionary<string, string> queryParams = null, IDictionary<string, string> headers = null);
        Task<TOut> Patch<TIn, TOut>(string endpoint, TIn val, IDictionary<string, string> queryParams = null, IDictionary<string, string> headers = null);
        Task Patch<TIn>(string endpoint, TIn val, IDictionary<string, string> queryParams = null, IDictionary<string, string> headers = null);
        Task<TOut> Put<TIn, TOut>(string endpoint, TIn val, IDictionary<string, string> queryParams = null, IDictionary<string, string> headers = null);
        Task Put<TIn>(string endpoint, TIn val, IDictionary<string, string> queryParams = null, IDictionary<string, string> headers = null);
        Task<T> Get<T>(string endpoint, IDictionary<string, string> queryParams = null, IDictionary<string, string> headers = null);
        Task Delete<T>(string endpoint, T value, IDictionary<string, string> queryParams = null, IDictionary<string, string> headers = null);
    }
}