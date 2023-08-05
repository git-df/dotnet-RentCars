using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Attributes.Commands.AddCarAtribute
{
    public class AddCarAtributeCommandValidator : AbstractValidator<AddCarAtributeCommand>
    {
        public AddCarAtributeCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Musisz podać nazwę");

            RuleFor(x => x.Value)
                .NotEmpty()
                .WithMessage("Musisz podać wartość");
        }
    }
}
