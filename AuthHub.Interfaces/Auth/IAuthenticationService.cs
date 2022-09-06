namespace AuthHub.Interfaces.Auth
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateOrganization(string username, string password);
    }
}
