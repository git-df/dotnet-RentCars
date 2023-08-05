using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Users.Commands.EditProfile
{
    public class EditProfileCommandValidator : AbstractValidator<EditProfileCommand>
    {
        public EditProfileCommandValidator() 
        {
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
