using AuthHub.Models.Requests;

namespace AuthHub.SDK.Interfaces
{
    public interface IClaimsConnector
    {
        Task SetClaims(SetClaimsRequest request);
    }
}
