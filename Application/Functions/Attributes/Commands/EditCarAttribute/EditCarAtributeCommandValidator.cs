using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Attributes.Commands.EditCarAttribute
{
    public class EditCarAtributeCommandValidator : AbstractValidator<EditCarAtributeCommand>
    {
        public EditCarAtributeCommandValidator()
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
