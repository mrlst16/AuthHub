﻿using AuthHub.Models.Organizations;
using AuthHub.Models.Passwords;
using AuthHub.Models.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Tokens
{
    public interface ITokenGenerator
    {
        Task<(byte[], byte[])> NewHash(PasswordRequest passwordRequest, Organization organization);
        Task<(byte[], byte[], IEnumerable<ClaimsKey>)> NewHash(string password, AuthSettings authSettings);

        /// <summary>
        /// Compares two hashes
        /// </summary>
        /// <param name="passwordInRepository"></param>
        /// <param name="passwordPassed"></param>
        /// <param name="salt"></param>
        /// <param name="length"></param>
        /// <param name="iterations"></param>
        /// <returns></returns>
        bool Authenticate(byte[] passwordInRepository, string passwordPassed, byte[] salt, int length, int iterations = 100);
    }
}
