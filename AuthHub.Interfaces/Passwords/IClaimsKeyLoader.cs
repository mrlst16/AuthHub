﻿using AuthHub.Models.Entities.Passwords;
using System;
using System.Collections.Generic;

namespace AuthHub.Interfaces.Passwords
{
    public interface IClaimsKeyLoader
    {
        Task<IEnumerable<ClaimsKey>> GetAsync(int authSettingsId);
        Task SaveAsync(IEnumerable<ClaimsKey> item);
    }
}
