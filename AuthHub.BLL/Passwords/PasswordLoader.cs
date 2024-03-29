﻿//using AuthHub.Interfaces.Organizations;
//using AuthHub.Interfaces.Passwords;
//using AuthHub.Interfaces.Users;
//using AuthHub.Models.Entities.Organizations;
//using AuthHub.Models.Entities.Passwords;
//using AuthHub.Models.Entities.Users;
//using Common.Interfaces.Providers;
//using Common.Interfaces.Repository;
//using System;
//using System.Threading.Tasks;

//namespace AuthHub.BLL.Passwords
//{
//    public class PasswordLoader : IPasswordLoader
//    {
//        private readonly IPasswordContext _passwordContext;
//        private readonly IOrganizationContext _organizationContext;
//        private readonly IUserContext _userContext;
//        private readonly ISRDRepository<Password, Guid> _passwordRepo;
//        private readonly ISRDRepository<User, Guid> _userRepo;
//        private readonly ISRDRepository<AuthSettings, Guid> _authSettingsRepo;
//        private readonly IDateProvider _dateProvider;

//        public PasswordLoader(
//            IPasswordContext passwordContext,
//            IOrganizationContext organizationContext,
//            IUserContext userContext,
//            ISRDRepository<Password, Guid> passwordRepo,
//            ISRDRepository<User, Guid> userRepo,
//            ISRDRepository<AuthSettings, Guid> authSettingsRepo,
//            IDateProvider dateProvider
//            )
//        {
//            _passwordContext = passwordContext;
//            _organizationContext = organizationContext;
//            _userContext = userContext;
//            _passwordRepo = passwordRepo;
//            _userRepo = userRepo;
//            _authSettingsRepo = authSettingsRepo;
//            _dateProvider = dateProvider;
//        }

//        public async Task<Password> Get(Guid organizationId, string authSettingsname, string username)
//            => await _passwordContext.Get(organizationId, authSettingsname, username);

//        public async Task<(bool, Password)> Set(Guid organizationId, string authSettingsname, Password request)
//        {
//            return await _passwordContext.Set(organizationId, authSettingsname, request);
//        }
//    }
//}
