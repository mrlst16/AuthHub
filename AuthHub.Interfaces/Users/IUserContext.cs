﻿using AuthHub.Models.Entities.Passwords;
using AuthHub.Models.Entities.Tokens;
using AuthHub.Models.Entities.Users;

namespace AuthHub.Interfaces.Users
{
    public interface IUserContext
    {
        Task<User> Create(User user);
        Task<User> GetAsync(int id);
        Task<User> GetAsync(int organizationId, string userName);
        Task<User> GetAsync(string userName);
        Task<int> SaveAsync(User item);
        Task AddToken(User user, Token token);
        Task UpdatePassword(User user, Password password, PasswordArchive archives);
        Task Update(User user);
        Task<User> GetByPhoneNumberAsync(string phoneNumber);
        Task<bool> SetDataAsync(int userId, string jsonData);
    }
}
