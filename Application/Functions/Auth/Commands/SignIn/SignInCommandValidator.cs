using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Auth.Commands.SignIn
{
    public class SignInCommandValidator : AbstractValidator<SignInCommand>
    {
        public SignInCommandValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Podaj poprawny email")
                .NotEmpty()
                .WithMessage("Musisz podać email");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Musisz podać hasło");
        }
    }
}
