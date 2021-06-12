using AuthHub.Models.Organizations;
using FluentValidation;

namespace AuthHub.Validators
{
    public class OrganizationSettingsValidator : AbstractValidator<AuthSettings>
    {
        public OrganizationSettingsValidator()
        {
            RuleFor(x => x.ExpirationMinutes)
                .GreaterThan(0);

            RuleFor(x => x.HashLength)
                .GreaterThan(0);

            RuleFor(x => x)
                .Must(x => x.Key.Trim().Length >= x.HashLength);
        }
    }
}
