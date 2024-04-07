using System.Threading.Tasks;
using AuthHub.Interfaces.Users;
using AuthHub.Models.Requests;
using FluentValidation;

namespace AuthHub.Api.Validators
{
    public class PhoneLoginCodeRequestValidator: AbstractValidator<PhoneLoginCodeRequest>
    {
        private readonly IUserContext _userContext;
        public PhoneLoginCodeRequestValidator(
            IUserContext userContext
            )
        {
            _userContext = userContext;

            RuleFor(x => x.PhoneNumber)
                .MustAsync(async (phoneNumber, token)
                    => await UserCanBeFoundByPhoneNumber(phoneNumber));
        }

        private async Task<bool> UserCanBeFoundByPhoneNumber(string phoneNumber)
        {
            var user = await _userContext.GetByPhoneNumberAsync(phoneNumber);
            return user != null;
        }
    }
}
