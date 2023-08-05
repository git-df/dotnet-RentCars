using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Offers.Commands.AddOffer
{
    public class AddOfferCommandValidator : AbstractValidator<AddOfferCommand>
    {
        public AddOfferCommandValidator() 
        {
            RuleFor(x => x.PricePerHour)
                .GreaterThan(0)
                .WithMessage("Podaj poprawną cenę");

            RuleFor(x => x.PricePreDay)
                .GreaterThan(0)
                .WithMessage("Podaj poprawną cenę");
        }
    }
}
