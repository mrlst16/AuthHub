﻿using System;
using AuthHub.Interfaces.Organizations;
using AuthHub.Models.Entities.Organizations;
using AuthHub.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthHub.Interfaces.Hashing;
using Common.Interfaces.Helpers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AuthHub.Models.Entities.Tokens;
using AuthHub.Models.Enums;
using AuthHub.Models.Options;
using Common.Interfaces.Providers;
using Microsoft.Extensions.Options;
using Common.Helpers;
using Token = AuthHub.Models.Tokens.Token;

namespace AuthHub.BLL.Organizations
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationContext _context;
        private readonly IHasher _hasher;
        private readonly IApplicationConsistency _applicationConsistency;
        private readonly IDateProvider _dateProvider;
        private readonly OrganizationsAuthOptions _options;

        public OrganizationService(
            IOrganizationContext context,
            IHasher hasher,
            IApplicationConsistency applicationConsistency,
            IDateProvider dateProvider,
            IOptions<OrganizationsAuthOptions> options
            )
        {
            _context = context;
            _hasher = hasher;
            _applicationConsistency = applicationConsistency;
            _dateProvider = dateProvider;
            _options = options.Value;
        }

        public async Task<Organization> CreateAsync(CreateOrganizationRequest request)
        {
            (var passwordHash, var salt) = _hasher.HashPasswordWithSalt(request.Password, 50, 10, 100);

            var org = new Organization()
            {
                Name = request.Name,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = salt,
                Settings = new AuthSettings()
                {
                    Audience = $"{request.Name}_Audience",
                    AuthScheme = AuthSchemeEnum.JWT,
                    ExpirationMinutes = 60 * 24 * 7,
                    HashLength = 128,
                    Iterations = 100,
                    Issuer = $"{request.Name}_Issuer",
                    SaltLength = 10,
                    Key = StringHelper.RandomAlphanumericString(64)
                }
            };
            await _context.Create(org);

            return org;
        }

        public async Task<Organization> GetAsync(int organizationId)
            => await _context.Get(organizationId);

        public async Task<Token> LoginAsync(OrganizationLoginRequest request)
        {
            var organization = await _context.Get(request.Name);

            var hash = _hasher.HashPasswordWithSalt(request.Password, organization.PasswordSalt, 50, 100);
            var authenticated = _applicationConsistency.BytesEqual(organization.PasswordHash, hash);
            if(!authenticated)
                throw new Exception("Login attempt failed");

            var securityKey = new SymmetricSecurityKey(_applicationConsistency.GetBytes(_options.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var expirationDate = _dateProvider.UTCNow.AddMinutes(_options.ExpirationMinutes);
            var token = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: new List<Claim>()
                {
                    new Claim("OrganizationId", organization.Id.ToString())
                },
                expires: expirationDate,
                signingCredentials: credentials
            );

            string value = new JwtSecurityTokenHandler().WriteToken(token);
            string refreshToken = StringHelper.RandomAlphanumericString(64);

            OrganizationToken organizationToken = new OrganizationToken()
            {
                Value = value,
                ExpirationDate = expirationDate,
                OrganizationId = organization.Id,
                RefreshToken = refreshToken
            };

            await _context.SaveOrganizationToken(organizationToken);

            return new Token()
            {
                Value = value,
                ExpirationDate = expirationDate,
                RefreshToken = refreshToken
            };
        }
    }
}