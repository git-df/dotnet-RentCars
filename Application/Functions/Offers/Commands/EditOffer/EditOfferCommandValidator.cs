using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Offers.Commands.EditOffer
{
    public class EditOfferCommandValidator : AbstractValidator<EditOfferCommand>
    {  
        public EditOfferCommandValidator() 
        {
            RuleFor(x => x.PricePerHour)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Podaj poprawną cenę");

            RuleFor(x => x.PricePreDay)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Podaj poprawną cenę");
        }
    }
}
