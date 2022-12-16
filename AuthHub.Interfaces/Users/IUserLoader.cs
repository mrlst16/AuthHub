﻿using System;
using AuthHub.Models.Entities.Users;

namespace AuthHub.Interfaces.Users
{
    public interface IUserLoader
    {
        Task<User> Create(User user);
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string username);
        Task<Guid> SaveAsync(User item);
    }
}
