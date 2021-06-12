using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthHub.WebUI.Connectors
{
    public interface IApiConnector
    {
        Task<TOut> Post<TIn, TOut>(string endpoint, TIn val);
        Task<T> Get<T>(string endpoint, IDictionary<string, string> headers = null);
    }
}
