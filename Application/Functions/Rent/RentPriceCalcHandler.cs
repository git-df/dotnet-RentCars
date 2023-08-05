using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Rent
{
    public static class RentPriceCalcHandler
    {
        public static decimal CalcPrice(DateTime fromDate, DateTime toDate, decimal pricePerHour, decimal pricePreDay)
        {
            decimal price = 0;

            var timeRent = toDate - fromDate;

            price += timeRent.Days * pricePreDay;

            price += Math.Min((decimal)(Math.Ceiling(timeRent.TotalHours) - (timeRent.Days * 24)) * pricePerHour, pricePreDay);

            return price;
        }
    }
}
