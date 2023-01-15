﻿using System.Threading.Tasks;
using AuthHub.Interfaces.Tokens;
using AuthHub.Models.Entities.Tokens;

namespace AuthHub.BLL.Tokens
{
    public class TokenLoader : ITokenLoader
    {
        public ITokenContext _context { get; set; }

        public TokenLoader(
            ITokenContext context
            )
        {
            _context = context;
        }

        public async Task Create(Token token)
            => await _context.Create(token);
    }
}