using System.Threading.Tasks;

namespace AuthHub.WebUI.Connectors
{
    public interface ILocalStorageProvider
    {
        Task<T> GetItem<T>(string key);
        Task SetItem<T>(string key, T value);
        Task RemoveItem(string key);
    }
}
