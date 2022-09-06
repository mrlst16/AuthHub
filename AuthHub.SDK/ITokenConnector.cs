﻿using AuthHub.Models.Requests;
using System.Threading.Tasks;
using AuthHubToken = AuthHub.Models.Tokens.Token;

namespace AuthHub.SDK
{
    public interface ITokenConnector
    {
        Task<AuthHubToken> GetOrganizationToken(string username, string password);
        Task<AuthHubToken> OrganizationSignIn(string username, string password);
        Task RequestPasswordReset(ResetOrganizationPasswordRequest request);
        Task SetPassword(SetPasswordRequest request);
    }
}
