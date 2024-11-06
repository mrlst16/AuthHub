using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Entities.Claims;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthHub.BLL.Passwords
{
    public class ClaimsKeyLoader : IClaimsKeyLoader
    {
        private readonly IClaimsKeyContext _context;

        public ClaimsKeyLoader(
            IClaimsKeyContext context
            )
        {
            _context = context;
        }
    }
}