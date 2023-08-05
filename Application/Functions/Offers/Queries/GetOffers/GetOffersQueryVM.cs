using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Offers.Queries.GetOffers
{
    public class GetOffersQueryVM
    {
        public int Id { get; set; }
        public decimal PricePreDay { get; set; }
        public decimal PricePerHour { get; set; }

        public CarInGetOffersQueryVM Car { get; set; }
        public BranchInGetOffersQueryVM Branch { get; set; }
    }

    public class CarInGetOffersQueryVM
    {
        public int Id { get; set; }
        public string PlaceNumber { get; set; }
        public string VIN { get; set; }

        public CarsModelInGetOffersQueryVM CarsModel { get; set; }
    }

    public class BranchInGetOffersQueryVM 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class CarsModelInGetOffersQueryVM 
    {
        public int Id { get; set; }
        public string BrandName { get; set; } 
        public string ModelName { get; set; }
    }
}
