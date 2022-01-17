//Adapted from https://stackoverflow.com/questions/63698112/storing-a-jwt-token-in-blazor-client-side

using AuthHub.SDK;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace AuthHub.WebUI.Connectors
{
    public class LocalStorageProvider : ILocalStorageProvider
    {
        private IJSRuntime _jsRuntime;

        public LocalStorageProvider(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<T> Get<T>(string key)
        {
            var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);

            if (json == null)
                return default;

            return JsonSerializer.Deserialize<T>(json);
        }

        public async Task Save<T>(string key, T value)
        {
            if (EqualityComparer<T>.Default.Equals(default(T)))
                return;

            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", key, JsonSerializer.Serialize(value));
        }

        public async Task Delete(string key)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }
    }
}
