using AuthHub.Models.Passwords;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthHub.Validators
{
    public class PasswordRequestValidator: AbstractValidator<PasswordRequest>
    {
        public PasswordRequestValidator()
        {

        }
    }
}
