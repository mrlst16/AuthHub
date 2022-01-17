using System.Threading.Tasks;

namespace AuthHub.SDK
{
    public interface ILocalStorageProvider
    {
        Task Save<T>(string key, T value);
        Task<T> Get<T>(string key);
        Task Delete(string key);
    }
}
