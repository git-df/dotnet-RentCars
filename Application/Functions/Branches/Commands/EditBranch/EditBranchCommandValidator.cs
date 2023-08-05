using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Branches.Commands.EditBranch
{
    public class EditBranchCommandValidator : AbstractValidator<EditBranchCommand>
    {
        public EditBranchCommandValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Musisz podać nazwę");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Musisz podać telefon");

            RuleFor(x => x.Address.Country)
                .NotEmpty()
                .WithMessage("Musisz podać kraj");

            RuleFor(x => x.Address.City)
                .NotEmpty()
                .WithMessage("Musisz podać miasto");

            RuleFor(x => x.Address.StreetWithNumber)
                .NotEmpty()
                .WithMessage("Musisz podać ulicę");

            RuleFor(x => x.Address.PostalCode)
                .NotEmpty()
                .WithMessage("Musisz podać kod mocztowy");
        }
    }
}
