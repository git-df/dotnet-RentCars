using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Models.Commands.AddModel
{
    public class AddModelCommandValidator : AbstractValidator<AddModelCommand>
    {
        public AddModelCommandValidator() 
        {
            RuleFor(x => x.BrandName)
                .NotEmpty()
                .WithMessage("Musisz podać markę");

            RuleFor(x => x.ModelName)
                .NotEmpty()
                .WithMessage("Musisz podać model");
        }
    }
}
