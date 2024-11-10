using AuthHub.Models.Entities.Claims;
using AuthHub.Models.Entities.Organizations;
using AuthHub.Models.Requests;
using System.Collections.Generic;

namespace AuthHub.Interfaces.Tokens
{
    public interface ITokenGenerator
    {
        Task<(byte[], byte[])> NewHash(PasswordRequest passwordRequest, Organization organization);
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
