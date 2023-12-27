﻿using AuthHub.Models.Tokens;

namespace AuthHub.SDK.Interfaces
{
    public interface ITokenConnector
    {
        Task<Token> GetJWTTokenAsync(string username, string password);
        Task<Token> RefreshJWTTokenAsync(Guid userId, string refreshToken);
    }
}
