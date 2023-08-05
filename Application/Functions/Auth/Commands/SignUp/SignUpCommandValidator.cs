using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Auth.Commands.SignUp
{
    public class SignUpCommandValidator : AbstractValidator<SignUpCommand>
    {
        public SignUpCommandValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Podaj poprawny email")
                .NotEmpty()
                .WithMessage("Musisz podać email");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Musisz podać hasło")
                .MinimumLength(8)
                .WithMessage("Hasło musi zawierać 8 znaków");

            RuleFor(x => x.UserInfo.PhoneNumber)
                .NotEmpty()
                .WithMessage("Musisz podać numer telefonu");

            RuleFor(x => x.UserInfo.PESEL)
                .NotEmpty()
                .WithMessage("Musisz podać kod PESEL");

            RuleFor(x => x.UserInfo.FirstName)
                .NotEmpty()
                .WithMessage("Musisz podać imię");

            RuleFor(x => x.UserInfo.LastName)
                .NotEmpty()
                .WithMessage("Musisz podać nazwisko");

            RuleFor(x => x.UserInfo.DateOfBirth)
                .NotEmpty()
                .WithMessage("Musisz podać datę urodzenia")
                .LessThan(DateTime.UtcNow.AddYears(-5))
                .WithMessage("Podaj poprawną datę");
        }
    }
}
