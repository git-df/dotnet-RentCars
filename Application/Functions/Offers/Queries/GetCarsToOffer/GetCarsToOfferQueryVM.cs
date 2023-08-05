using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Offers.Queries.GetCarsToOffer
{
    public class GetCarsToOfferQueryVM
    {
        public int Id { get; set; }
        public string PlaceNumber { get; set; }
        public string VIN { get; set; }
        public int Year { get; set; }

        public CarsModelInGetCarsToOfferQuerryVM CarsModel { get; set; }
    }

    public class CarsModelInGetCarsToOfferQuerryVM
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
    }
}
