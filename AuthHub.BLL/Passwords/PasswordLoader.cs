//using AuthHub.Interfaces.Organizations;
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
//        private readonly ISRDRepository<Password, int> _passwordRepo;
//        private readonly ISRDRepository<User, int> _userRepo;
//        private readonly ISRDRepository<AuthSettings, int> _authSettingsRepo;
//        private readonly IDateProvider _dateProvider;

//        public PasswordLoader(
//            IPasswordContext passwordContext,
//            IOrganizationContext organizationContext,
//            IUserContext userContext,
//            ISRDRepository<Password, int> passwordRepo,
//            ISRDRepository<User, int> userRepo,
//            ISRDRepository<AuthSettings, int> authSettingsRepo,
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

//        public async Task<Password> GetAsync(int organizationId, string authSettingsname, string username)
//            => await _passwordContext.GetAsync(organizationId, authSettingsname, username);

//        public async Task<(bool, Password)> Set(int organizationId, string authSettingsname, Password request)
//        {
//            return await _passwordContext.Set(organizationId, authSettingsname, request);
//        }
//    }
//}
