﻿using AuthHub.Interfaces.Users;
using AuthHub.Models.Entities.Passwords;
using AuthHub.Models.Entities.Tokens;
using AuthHub.Models.Entities.Users;
using AuthHub.Models.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AuthHub.BLL.Users
{
    public class UserLoader : IUserLoader
    {
        private readonly IUserContext _userContext;

        public UserLoader(
            IUserContext userContext
            )
        {
            _userContext = userContext;
        }

        public async Task<User> Create(User user)
            => await _userContext.Create(user);

        public async Task<User> GetAsync(int id, bool requiresVerification = true)
        {
            var result = await _userContext.GetAsync(id);
            if (!requiresVerification) return result;

            return result;
        }

        public async Task<User> GetAsync(string username)
            => await _userContext.GetAsync(username);

        public async Task<int> SaveAsync(User item)
            => await _userContext.SaveAsync(item);

        public async Task AddToken(User user, Token token)
            => await _userContext.AddToken(user, token);

        public async Task UpdatePassword(User user, Password password, PasswordArchive archives)
            => await _userContext.UpdatePassword(user, password, archives);

        public async Task Update(User user)
            => await _userContext.Update(user);

        public async Task<User> GetByPhoneNumberAsync(string phoneNumber)
        {
            //We are NOT requiring verification of the phone since this is part of phone login
            //And it wouldn't make sense because we are going to require the phone number on login
            //which acts as a verification

            return await _userContext.GetByPhoneNumberAsync(phoneNumber);
        }
    }
}
