using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Auth.Commands.PasswordChange
{
    public class PasswordChangeCommandValidator : AbstractValidator<PasswordChangeCommand>
    {
        public PasswordChangeCommandValidator() 
        {
            RuleFor(x => x.OldPassword)
                .NotEmpty()
                .WithMessage("Musisz podać obecne hasło");

            RuleFor(x => x.NewPassword)
                .NotEmpty()
                .WithMessage("Musisz podać nowe hasło")
                .MinimumLength(8)
                .WithMessage("Nowe hasło musi zawierać 8 znaków");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.NewPassword)
                .WithMessage("Hasła nie są takie same");
        }
    }
}
