using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Entities.Claims;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthHub.BLL.Passwords
{
    public class ClaimsKeyService : IClaimsKeyService
    {
        private readonly IClaimsKeyLoader _loader;

        public ClaimsKeyService(
            IClaimsKeyLoader loader
            )
        {
            _loader = loader;
        }
    }
}
