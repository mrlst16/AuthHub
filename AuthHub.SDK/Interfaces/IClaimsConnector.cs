using AuthHub.Models.Requests.Claims;

namespace AuthHub.SDK.Interfaces
{
    public interface IClaimsConnector
    {
        Task AddClaimsAsync(AddClaimsRequest request);
        Task RemoveClaimsAsync(RemoveClaimsRequest request);
        Task SetClaimsAsync(SetClaimsRequest request);
    }
}
