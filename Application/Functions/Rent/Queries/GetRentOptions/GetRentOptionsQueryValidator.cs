using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Rent.Queries.GetRentOptions
{
    public class GetRentOptionsQueryValidator : AbstractValidator<GetRentOptionsQuery>
    {
        public GetRentOptionsQueryValidator()
        {
            RuleFor(x => x.DateFrom)
                .GreaterThan(new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.AddDays(1).Day))
                .WithMessage("Rezerwować możesz na najwcześniej na jutro");

            RuleFor(x => x.DateTo)
                .GreaterThan(x => x.DateFrom.AddHours(1))
                .WithMessage("Minimalny czas rezrerwacji to godzina")
                .LessThan(x => x.DateFrom.AddDays(5))
                .WithMessage("Maksymalny czas rezrerwacji to pięć dni");
        }
    }
}
