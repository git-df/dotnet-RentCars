using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Cars.Commands.EditCar
{
    public class EditCarCommandValidator : AbstractValidator<EditCarCommand>
    {
        public EditCarCommandValidator() 
        {
            RuleFor(x => x.VIN)
                .NotEmpty()
                .WithMessage("Musisz podać VIN");

            RuleFor(x => x.PlaceNumber)
                .NotEmpty()
                .WithMessage("Musisz podać rejestracje");

            RuleFor(x => x.Fuel)
                .NotEmpty()
                .WithMessage("Musisz podać rodzaj paliwa");

            RuleFor(x => x.Year)
                .GreaterThan(1900)
                .WithMessage("Podaj poprawny rok");
        }
    }
}
